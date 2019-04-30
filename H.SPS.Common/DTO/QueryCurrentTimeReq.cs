using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 获取时间请求参数
    /// </summary>
    public class QueryCurrentTimeReq:RequestInfo
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CurrentTime = DateTime.Now;
    }
    /// <summary>
    /// 获取时间返回结果
    /// </summary>
    public class QueryCurrentTimeRes : ResponseInfo
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CurrentTime = DateTime.Now;
    }
}
