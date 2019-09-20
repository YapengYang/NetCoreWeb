using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading;
using NLog.Web;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using H.NCore.AppService;

namespace H.NCore.WinServiceHost
{
    public class AppBaseService 
    {
        string _Url = "";
        IAppService _Service;
        IWebHost _Host;
        public AppBaseService(string url, IAppService service)
        {
            _Url = url;
            _Service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            try
            {

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
   
                _Host.RunAsync();

            }
            catch (Exception ex)
            {
                //NLog: catch setup errors

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

            }
        }

        void run()
        {

        }
    }
}
