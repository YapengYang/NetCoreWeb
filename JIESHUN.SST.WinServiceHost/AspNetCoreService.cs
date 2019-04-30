using Microsoft.AspNetCore;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System.Reflection;
using H.SPS.Common;
using System.Threading;
using NLog;

namespace H.SPS.WinServiceHost
{

    public class AspNetCoreService : IMicroService
    {
        string _Url = "";
        IService _Service;
        IWebHost _Host;
        Logger _Logger = null;
        public AspNetCoreService(string url, IService service)
        {
            _Url = url;
            _Service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            _Logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                _Logger.Info("ASP.NET CORE框架正在启动 ...CPU" + (IntPtr.Size == 4 ? "32位" : "64位"));
                string root = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
                _Host = WebHost.CreateDefaultBuilder()
                    .UseUrls(_Url)
                    .UseContentRoot(root)
                    .ConfigureLogging((hostingContext, logging) =>
                    {
                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        //logging.AddDebug();
                    })
                    .UseNLog()
                    .UseStartup<Startup>()
                    .ConfigureServices((ioc) =>
                    {
                        _Service.Initialize(ioc);
                    })
                    .Build();
                _Service.Start();
                _Logger.Info("ASP.NET CORE Run ...");
                _Host.RunAsync();

            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                _Logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            _Logger.Info("Service stopping ...");
            try
            {
                if (_Host != null)
                {
                    _Host.StopAsync().Wait();
                }
                Thread.Sleep(200);

                _Service.Stop();
            }
            catch (Exception ex)
            {
                _Logger.Error(ex.ToString());
            }
            LogManager.Shutdown();
        }

        void run()
        {

        }
    }
}
