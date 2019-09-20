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


namespace H.NCore.AppService
{

    public interface IAppService
    {
        string GetName();
        string GetDisplayName();
        string GetDescription();

        void Initialize(IServiceCollection services);

        void Start();

        void Stop();

    }
}
