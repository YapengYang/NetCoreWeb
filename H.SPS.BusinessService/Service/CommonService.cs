using H.SPS.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.CommonService
{
    /// <summary>
    /// 公共服务
    /// </summary>
    [Route("Common")]
    public class CommonService 
    {   
        /// <summary>
        /// 获取服务器时间
        /// </summary>    
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation("GetServiceTime")]
        public DateTime GetServiceTime()
        {
            return DateTime.Now;
        }


    }
}
