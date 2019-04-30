using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;
namespace H.SPS.Common
{
    /// <summary>
    /// 生成对象的描述信息
    /// </summary>
    public class ObjectParser
    {
        public static ObjectModel GetModel(object obj) 
        {
            Type t = obj.GetType();
            if (typeof(IEnumerable<object>).IsAssignableFrom(t))
                throw new Exception("ObjectParser.Parser不支持集合");
            ObjectModel root = parserObject(t,obj,true);
            return root;
        }
        public static object GetObject(ObjectModel model)
        {
            return parserModel(model, null);
        }
        public static object parserModel(ObjectModel model,object parent)
        {
            object instance = null;
            if (model.FieldType.Length>0)
            {
                Type type = Type.GetType(model.FieldType);
                instance=Activator.CreateInstance(type);//复杂类型或List
                if(parent!=null)
                {
                    var parentType = parent.GetType();
                    bool isList = typeof(IEnumerable<object>).IsAssignableFrom(parentType);
                    if(isList)
                    {
                        var addMethod = parentType.GetMethod("Add");
                        if(addMethod!=null)
                        {
                            addMethod.Invoke(parent, new object[] { instance });
                        }
                    }
                    else
                    {
                        var membeInfo = parentType.GetMember(model.FieldName);
                        if (membeInfo.Length > 0)
                        {
                            if (membeInfo[0].MemberType == MemberTypes.Field)
                            {
                                var f = (FieldInfo)membeInfo[0];
                                f.SetValue(parent, instance);
                            }
                            else if (membeInfo[0].MemberType == MemberTypes.Property)
                            {
                                var f = (PropertyInfo)membeInfo[0];
                                f.SetValue(parent, instance);
                            }

                        }
                        else
                        {
                            throw new Exception("没有找到字段" + model.FieldName);
                        }
                    }
                    
                }
            }
            else
            {
                instance = parent;
            }
            
            foreach(var field in model.FieldList)
            {
                var membeInfo = instance.GetType().GetMember(field.FieldName);
                if (membeInfo.Length > 0)
                {
                    if (membeInfo[0].MemberType == MemberTypes.Field)
                    {
                        var f = (FieldInfo)membeInfo[0];
                        if(f.FieldType.IsEnum)
                            f.SetValue(instance, int.Parse(field.CurrentValue.ToString()));
                        else
                            f.SetValue(instance, field.CurrentValue);
                    }
                    else if (membeInfo[0].MemberType == MemberTypes.Property)
                    {
                        var f = (PropertyInfo)membeInfo[0];
                        f.SetValue(instance, field.CurrentValue);
                    }

                }
                else
                {
                    throw new Exception("没有找到字段" + model.FieldName);
                }

            }
            foreach(var subModel in model.Children)
            {
                parserModel(subModel, instance);

            }
            return instance;
        }
        static ObjectModel parserObject(Type t, object instance, bool isRoot = false)
        {
            ObjectModel root = new ObjectModel();
            root.FieldType = t.FullName;
            List<MemberInfo> props = new List<MemberInfo>();
            t.GetProperties(BindingFlags.Public | BindingFlags.Instance /*| BindingFlags.DeclaredOnly*/).ToList().ForEach(x =>
            {
                var attr = Attribute.GetCustomAttribute(x, typeof(BrowsableAttribute)) as BrowsableAttribute;
                if (attr == null || attr.Browsable)
                {
                    props.Add(x);
                }

            });
            t.GetFields(BindingFlags.Public | BindingFlags.Instance /*| BindingFlags.DeclaredOnly*/).ToList().ForEach(x =>
            {
                var attr = Attribute.GetCustomAttribute(x, typeof(BrowsableAttribute)) as BrowsableAttribute;
                if (attr == null || attr.Browsable)
                {
                    props.Add(x);
                }

            });

            List<ObjectModel> subModels = new List<ObjectModel>();
            root.Children = subModels;
            foreach (var p in props)
            {
                object fieldValue = null;

                Type memberType = null;
                if (p.MemberType == MemberTypes.Field)
                {
                    memberType = ((FieldInfo)p).FieldType;
                    if (instance != null)
                        fieldValue = ((FieldInfo)p).GetValue(instance);
                }
                else if (p.MemberType == MemberTypes.Property)
                {
                    memberType = ((PropertyInfo)p).PropertyType;
                    if (instance != null)
                        fieldValue = ((PropertyInfo)p).GetValue(instance);
                }
                bool isList = typeof(IEnumerable<object>).IsAssignableFrom(memberType);
                //bool isDictionary= typeof(Dictionary<string, object>).IsAssignableFrom(memberType);
                //bool isGenericComplexType = false;
                bool isComplexType = !memberType.Namespace.StartsWith("System") && !memberType.IsEnum;

                if (isComplexType && !isList && memberType.IsGenericType) continue;
                ObjectModel attachModel = null;
                var categoryAttr = p.GetCustomAttribute<CategoryAttribute>();
                if (categoryAttr != null)
                {
                    attachModel = subModels.Find(x => x.Label == categoryAttr.Category);
                    if (attachModel == null)
                    {
                        attachModel = new ObjectModel();
                        attachModel.Label = categoryAttr.Category;
                        subModels.Add(attachModel);
                    }
                }
                else if (isRoot && !isComplexType && !isList)
                {
                    string category = "基本设置";
                    attachModel = subModels.Find(x => x.Label == category);
                    if (attachModel == null)
                    {
                        attachModel = new ObjectModel();
                        attachModel.Label = category;
                        subModels.Add(attachModel);
                    }
                }
                else
                {
                    attachModel = root;
                }
                string displayName = p.Name;
                var displayNameAttr= p.GetCustomAttribute<DisplayNameAttribute>();
                if (displayNameAttr != null)
                    displayName = displayNameAttr.DisplayName;
                
                if (isList)
                {
                    var addableAttr = p.GetCustomAttribute<AddDeleteableAttribute>();
                    bool addable = false;
                    List<object> addableModels = new List<object>();
                    if (addableAttr != null)
                    {
                        addable = addableAttr.IsAddDeleteable;

                    }

                    ObjectModel collectionModel = new ObjectModel();
                    collectionModel.Label = displayName;
                    collectionModel.FieldType = memberType.FullName;
                    collectionModel.FieldName = p.Name;
                    collectionModel.Children = new List<ObjectModel>();
                    collectionModel.AddableModels = new List<ObjectModel>();
                    collectionModel.IsList = true;
                    collectionModel.AddDeleteable = addable;
                    attachModel.Children.Add(collectionModel);
                    IEnumerable<object> items =(IEnumerable<object>) fieldValue;
                    if(items!=null)
                    {
                        foreach(var obj in items)
                        {
                            if (obj == null) continue;
                            //这里校验是否为自定义类型
                            Type objType = obj.GetType();
                            if (objType.Namespace.StartsWith("System")) continue;
                            var m = parserObject(objType, obj);
                            string c = Guid.NewGuid().ToString();
                            FieldInfo fi = objType.GetField("Name");
                            PropertyInfo pi = objType.GetProperty("Name");
                            if (fi != null) c=fi.GetValue(obj).ToString();
                            if (pi != null) c = pi.GetValue(obj).ToString();
                            m.Label = c;
                            
                            m.IsListItem = true;
                            m.AddDeleteable = addable;
                            collectionModel.Children.Add(m);
                        }
                        
                    }
                    var genericType = memberType.GetGenericArguments()[0];
                    List<Type> knownTypes = new List<Type>();
                    var knownTypeAttrs = genericType.GetCustomAttributes<KnownTypeAttribute>().ToList();
                    foreach(var attr in  knownTypeAttrs)
                    {
                        if(string.IsNullOrEmpty(attr.MethodName))
                        {
                            knownTypes.Add(attr.Type);
                        }
                    }
                    if (knownTypes.Count == 0) knownTypes.Add(genericType);
          
                    foreach (var objType in knownTypes)
                    {
                        object obj = Activator.CreateInstance(objType);
                        if (obj == null) continue;
                        //这里校验是否为自定义类型
                        
                        if (objType.Namespace.StartsWith("System")) continue;
                        var m = parserObject(objType, obj);
                        string c = Guid.NewGuid().ToString();
                        FieldInfo fi = objType.GetField("Name");
                        PropertyInfo pi = objType.GetProperty("Name");
                        if (fi != null) c = fi.GetValue(obj).ToString();
                        if (pi != null) c = pi.GetValue(obj).ToString();
                        m.Label = c;
                        m.IsListItem = true;
                        m.AddDeleteable = addable;
                        collectionModel.AddableModels.Add(m);
                    }
                    
                    
                    //var m = parserObject(memberType.GetGenericArguments()[0]);
                    //m.Category = displayName;  
                }
                else if (isComplexType)
                {
                    var m = parserObject(memberType,fieldValue);
                    m.Label = displayName;
                    m.FieldName = p.Name;
                    attachModel.Children.Add(m);
                }
                else
                {
                    ObjectField field = parserField(p,instance);
                    attachModel.FieldList.Add(field);
                }
            }
            return root;
        }
        static ObjectField parserField(MemberInfo p,object instance)
        {
            Type memberType = null;
            Object currentValue = null;
            if (p.MemberType == MemberTypes.Field)
            {
                memberType = ((FieldInfo)p).FieldType;
                if (instance != null)
                    currentValue = ((FieldInfo)p).GetValue(instance);
            }
            else if (p.MemberType == MemberTypes.Property)
            {
                memberType = ((PropertyInfo)p).PropertyType;
                if (instance != null)
                    currentValue = ((PropertyInfo)p).GetValue(instance);
            }

            ObjectField field = new ObjectField();
            field.FieldName = p.Name;
            field.DisplayName = p.Name;
            field.CurrentValue = currentValue;

            var displayAttr = p.GetCustomAttribute<DisplayNameAttribute>();
            if (displayAttr != null) field.DisplayName = displayAttr.DisplayName;
            field.Editable = true;
            var editableAttr= p.GetCustomAttribute<EditableAttribute>();
            if (editableAttr != null) field.Editable = editableAttr.AllowEdit;
            
            var requiredAttr = p.GetCustomAttribute<RequiredAttribute>();
            if (requiredAttr != null)
            {
                field.ValidItems.Add(new ValidItem {
                    ValidType= "Required",
                    ValidMessage = "*必填项",
                });
            }
            var rangeAttr = p.GetCustomAttribute<RangeAttribute>();
            if (rangeAttr != null)
            {
                field.ValidItems.Add(new ValidItem
                {
                    ValidType = "Range",
                    ValidMessage = rangeAttr.ErrorMessage,
                    ValidValue1 = rangeAttr.Minimum,
                    ValidValue2 = rangeAttr.Maximum
                });
            }
            var regexAttr = p.GetCustomAttribute<RegularExpressionAttribute>();
            if (regexAttr != null)
            {
                field.ValidItems.Add(new ValidItem
                {
                    ValidType = "Regex",
                    ValidMessage = regexAttr.ErrorMessage,
                    ValidValue1 = regexAttr.Pattern
                });
            }
            var minLenAttr = p.GetCustomAttribute<MinLengthAttribute>();
            if (minLenAttr != null)
            {
                field.ValidItems.Add(new ValidItem
                {
                    ValidType = "MinLength",
                    ValidMessage = minLenAttr.ErrorMessage,
                    ValidValue1 = minLenAttr.Length
                });
            }
            var maxLenAttr = p.GetCustomAttribute<MinLengthAttribute>();
            if (maxLenAttr != null)
            {
                field.ValidItems.Add(new ValidItem
                {
                    ValidType = "MaxLength",
                    ValidMessage = maxLenAttr.ErrorMessage,
                    ValidValue1 = maxLenAttr.Length
                });
            }
            if (memberType.IsEnum)
            {
                field.FieldType = "int";
                field.Selectable = true;
                field.CurrentValue = (int)(currentValue);
                field.EnumValues = new List<EnumValue>();
                Array values=Enum.GetValues(memberType);
                foreach(var val in values)
                {
                    EnumValue ev = new EnumValue();
                    ev.IntValue = Convert.ToInt32(val);
                    string name = Enum.GetName(memberType, val);

                    FieldInfo f = memberType.GetField(name);
                    DisplayNameAttribute displayNameAttribute = Attribute.GetCustomAttribute(f,typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    if(displayNameAttribute!=null)
                    {
                        ev.DisplayName = displayNameAttribute.DisplayName;
                    }
                    else
                    {
                        ev.DisplayName = name;
                    }
                    field.EnumValues.Add(ev);
                }
            }
            else if (memberType == typeof(int))
            {
                field.FieldType = "int";
            }
            else if (memberType == typeof(bool))
            {
                field.FieldType = "bool";
            }
            else if(memberType == typeof(string))
            {
                field.FieldType = "string";
            }
            else if (memberType == typeof(DateTime))
            {
                field.FieldType = "datetime";
            }
            else if (memberType == typeof(float) || memberType == typeof(decimal) || memberType == typeof(double))
            {
                field.FieldType = "float";
            }
            else
            {
                throw new Exception("不支持的数据类型");
            }
               
            return field;
        }

    }
}
