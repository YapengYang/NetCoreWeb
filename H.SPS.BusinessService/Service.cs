using H.SPS.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
namespace H.SPS.CommonService
{
    /// <summary>
    /// 
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return "设备服务守护进程";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDisplayName()
        {
            return "SST.BusinessService";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "SSTBusinessService";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void Initialize(IServiceCollection services)
        {
            ///// <summary>
            ///// 
            ///// </summary>
            ///// <returns></returns>
            //public List<Type> GetAll()
            //{
            //    return new List<Type>()
            //{
            //    typeof(VistorService)
            //};
            //}
            services.AddSingleton<IServiceRegister>(new CommonRegister());
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void UnInitialize()
        {
            //throw new NotImplementedException();
        }
    }
}