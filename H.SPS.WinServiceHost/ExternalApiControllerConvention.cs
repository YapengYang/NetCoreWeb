using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H.SPS.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Internal;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace H.SPS.WinServiceHost
{
    
    public class ExternalApiControllerConvention: IApplicationModelConvention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public void Apply(ApplicationModel application)
        {
            var controllerRegister = Env.Instance.ApplicationServices.GetService<IControllerRegister>();
            if (controllerRegister == null) return;
            var controllers = controllerRegister.GetAll();
            foreach (var controller in controllers)
            {

                var controllName = controller.Name;
                if (controllName.EndsWith("Controller"))
                    controllName = controllName.Substring(0, controllName.Length - "Controller".Length);
                var controllAttrs = controller.GetCustomAttributes().ToList();
                var routeAttr = (RouteAttribute)controllAttrs.Find(x => typeof(RouteAttribute).IsAssignableFrom(x.GetType()));
                var model = new ControllerModel(controller.GetTypeInfo(), controllAttrs);
                model.ControllerName = controllName;
                //model.ControllerName = controllName;
                string template = $"{controllName}";
                if (routeAttr!=null)
                {
                    template = routeAttr.Template;
                }
                model.Selectors.Add(new SelectorModel()
                {
                    AttributeRouteModel = new AttributeRouteModel()
                    {
                        Template = template
                    }
                });

                var methods = controller.GetMethods(BindingFlags.Public| BindingFlags.DeclaredOnly| BindingFlags.Instance);
                foreach(var method in methods)
                {
                    var methodAttrs = method.GetCustomAttributes().ToList();
                    var httpAttr =(HttpMethodAttribute) methodAttrs.Find(x => typeof(HttpMethodAttribute).IsAssignableFrom(x.GetType()));
                    string actionTemplate = method.Name;
                    if (httpAttr != null && !string.IsNullOrWhiteSpace(httpAttr.Template))
                        actionTemplate = httpAttr.Template;
                    //methodAttrs.Add(new SwaggerOperationAttribute(method.Name));
                    var actionModel = new ActionModel(method, methodAttrs);
                    actionModel.ActionName = method.Name;
                    actionModel.Controller = model;
                    //actionModel.Selectors.Add(new SelectorModel());
                    var selectModel = new SelectorModel()
                    {
                        AttributeRouteModel = new AttributeRouteModel()
                        {
                            Template = actionTemplate
                        }
                    };
                    if(httpAttr!=null)
                        selectModel.ActionConstraints.Add(new HttpMethodActionConstraint(httpAttr.HttpMethods) {

                    });
                    actionModel.Selectors.Add(selectModel);
                    var paras = method.GetParameters();
                    foreach (var p in paras)
                    {
                        var paraAttrs = p.GetCustomAttributes().ToList();
                        ParameterModel pm = new ParameterModel(p, paraAttrs);
                        pm.Action = actionModel;
                        pm.ParameterName = p.Name;
                        
                        var fromBodyAttr = p.GetCustomAttribute<FromBodyAttribute>();
                        var fromFormAttr = p.GetCustomAttribute<FromFormAttribute>();
                        var fromQueryAttr = p.GetCustomAttribute<FromQueryAttribute>();
                        var fromHeaderAttr = p.GetCustomAttribute<FromHeaderAttribute>();
                        var fromRouteAttr = p.GetCustomAttribute<FromRouteAttribute>();
                        var fromServicesAttr = p.GetCustomAttribute<FromServicesAttribute>();
                        if(fromBodyAttr != null)
                        {
                            pm.BindingInfo = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo();
                            pm.BindingInfo.BindingSource = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource("Body","Body",true,true);
                        }
                        else if (fromFormAttr != null)
                        {
                            pm.BindingInfo = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo();
                            pm.BindingInfo.BindingSource = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource("Form", "Form", true, true);
                        }
                        else if (fromQueryAttr != null)
                        {
                            pm.BindingInfo = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo();
                            pm.BindingInfo.BindingSource = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource("Query", "Query", true, true);
                        }
                        else if (fromHeaderAttr != null)
                        {
                            pm.BindingInfo = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo();
                            pm.BindingInfo.BindingSource = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource("Header", "Header", true, true);
                        }
                        else if (fromRouteAttr != null)
                        {
                            pm.BindingInfo = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo();
                            pm.BindingInfo.BindingSource = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource("Route", "Route", true, true);
                        }
                        else if (fromServicesAttr != null)
                        {
                            pm.BindingInfo = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo();
                            pm.BindingInfo.BindingSource = new Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource("Services", "Services", true, true);
                        }
                        actionModel.Parameters.Add(pm);
                    }

                    model.Actions.Add(actionModel);

                }
                application.Controllers.Add(model);
            }
            
        }
    }
}
