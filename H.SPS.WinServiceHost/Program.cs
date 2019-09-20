using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using H.SPS.Common;
using NLog.Web;

namespace H.SPS.WinServiceHost
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        static IService bizService = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Info("\r\n------------------------软件启动-------------------");
            string url = args.FirstOrDefault(x => x.ToLower().StartsWith("serviceurl:"));
            if (url == null)
            {
                logger.Error("url为空");
                return;
            }
            url = url.Substring(url.IndexOf(':') + 1);

            string serviceDllPath = args.FirstOrDefault(x => x.ToLower().StartsWith("servicepath:"));
            if (serviceDllPath == null)
            {
                logger.Error("serviceDllPath==null");
                return;
            }
            serviceDllPath = serviceDllPath.Split(":")[1].Trim();
            string fullPath = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, serviceDllPath);
            if (!File.Exists(fullPath))
            {
                logger.Error($"路径{fullPath}不存在");
                return;
            }
            var asm = Assembly.LoadFrom(fullPath);
            var serviceType = asm.GetExportedTypes().FirstOrDefault(x => typeof(IService).IsAssignableFrom(x));
            if (serviceType == null)
            {
                logger.Error($"程序集{serviceDllPath}中不存在IService的类型");
                return;
            }
            bizService = (IService)Activator.CreateInstance(serviceType);
            if (bizService == null)
            {
                logger.Error($"程序集{serviceDllPath}中创建IService的类型失败");
                return;
            }
            Startup.DllFullPath = fullPath;
            //ServiceRunner<AspNetCoreService>.Run(config =>
            //{
            //    var name = config.GetDefaultName();
            //    config.Service(serviceConfig =>
            //    {
            //        serviceConfig.ServiceFactory((extraArguments, controller) =>
            //        {
            //            return new AspNetCoreService(url, bizService);
            //        });
            //        serviceConfig.OnStart((service, extraArguments) =>
            //        {
            //            logger.Info("Service {0} started", name);
            //            service.Start();
            //        });

            //        serviceConfig.OnStop(service =>
            //        {
            //            logger.Info("Service {0} stopped", name);
            //            service.Stop();
            //        });

            //        serviceConfig.OnError(e =>
            //        {
            //            logger.Error("Service {0} errored with exception : {1}", name, e.Message);
            //        });
            //    });

            //    config.SetName(bizService.GetName());
            //    config.SetDescription(bizService.GetDescription());
            //    config.SetDisplayName(bizService.GetDisplayName());
            //});
        }
    }
}
