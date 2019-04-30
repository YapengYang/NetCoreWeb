using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    public interface IService
    {
        string GetName();
        string GetDisplayName();
        string GetDescription();

        void Initialize(IServiceCollection services);

        void Start();

        void Stop();

    }
}
