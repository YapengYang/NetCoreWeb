using H.SPS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.CommonService
{
    /// <summary>
    /// 公共服务注册类
    /// </summary>
    public class CommonRegister : IServiceRegister
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Type> GetAll()
        {
            return new List<Type>()
            {
                typeof(CommonService)
            };
        }
    }
}
