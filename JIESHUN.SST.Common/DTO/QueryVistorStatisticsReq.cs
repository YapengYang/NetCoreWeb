using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 获取访客当日统计数据请求参数
    /// </summary>
    public class QueryVistorStatisticsReq:RequestInfo
    {
    }
    /// <summary>
    /// 获取访客当日统计数据返回内容
    /// </summary>
    public class QueryVistorStatisticsRes:RequestInfo
    {
        /// <summary>
        /// 当日申请人数
        /// </summary>
        public int ApplyCount = 0;
        /// <summary>
        /// 当日到访人数
        /// </summary>
        public int ArrivedCount = 0;
    }
}
