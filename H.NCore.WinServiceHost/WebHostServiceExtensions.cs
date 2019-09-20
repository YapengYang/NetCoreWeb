using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;
using H.NCore.AppService;

namespace H.NCore.WinServiceHost
{
    #region ExtensionsClass
    public static class WebHostServiceExtensions
    {
        public static void RunAsCustomService(this IWebHost host)
        {
            //var webHostService = new AppServiceA(host);
            //ServiceBase.Run(webHostService);
        }
    }
    #endregion
}
