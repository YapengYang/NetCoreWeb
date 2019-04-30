using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 获取访客申请结果请求参数
    /// </summary>
    public class QueryVistorApproveResultReq : RequestInfo
    {
        /// <summary>
        /// 请求的类型，0：身份证号 1:取证码
        /// </summary>
        public int RequestType = 0;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNO = "";
        /// <summary>
        /// 取证码
        /// </summary>
        public string Code = "";
    }
    /// <summary>
    /// 获取访客申请结果返回内容
    /// </summary>
    public class QueryVistorApproveResultRes : ResponseInfo
    {
        /// <summary>
        /// 返回未过期的记录
        /// </summary>
        public List<VistorApproveResult> Records = new List<VistorApproveResult>();
    }
}
