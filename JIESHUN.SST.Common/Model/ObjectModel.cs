using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace H.SPS.Common
{

    public class ObjectModel
    {
        public string FieldType="";
        public string FieldName="";
        public string Label="";
        public bool IsList = false;
        public bool IsListItem = false;
        public bool AddDeleteable = true;
        //public object DefaultValue;
        public List<ObjectModel> Children=new List<ObjectModel>();
        public List<ObjectModel> AddableModels = new List<ObjectModel>();
        public List<ObjectField> FieldList=new List<ObjectField>();
    }
    public class ObjectField
    {
        
        public string FieldType="";
        public string FieldName="";
        public string DisplayName="";
        public string ErrorMessage = "";
        public object CurrentValue;
        //0:none 1:List 2:Table
        public int  ListStyle;
        public bool Selectable;
        public bool Editable = true;
        public List<EnumValue> EnumValues=new List<EnumValue>();
        //0:Combobox (DropDown List) 1:Combobox 2 Radio Box
        public int EnumStyle;
        public List<ValidItem> ValidItems = new List<ValidItem>();
        //public bool Required;
        //public string Regex;
        //public int? MinLenth;
        //public int? MaxLenth;
        //public decimal? MinValue;
        //public decimal? MaxValue;
    }

    public class EnumValue
    {
        public int IntValue;
        public string DisplayName="";
    }
    public class ValidItem
    {
        public string ValidMessage;
        public string ValidType;
        public object ValidValue1;
        public object ValidValue2;
    }
}
