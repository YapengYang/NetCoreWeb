using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 获取访客机策略请求参数
    /// </summary>
    public class QueryVistorStrategyReq : RequestInfo
    {
    }
    /// <summary>
    /// 获取访客机策略返回内容
    /// </summary>
    public class QueryVistorStrategyRes : ResponseInfo
    {
        /// <summary>
        /// 访客机策略
        /// </summary>
        public VistorStrategyInfo Strategy = new VistorStrategyInfo();
    }
}
