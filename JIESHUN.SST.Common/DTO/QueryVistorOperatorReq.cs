using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 获取访客机操作员信息请求参数
    /// </summary>
    public class QueryVistorOperatorReq : RequestInfo
    {
        /// <summary>
        /// 操作员编号，例如：9999
        /// </summary>
        public string NO = "";//编号
        /// <summary>
        /// 操作员密码
        /// </summary>
        public string PWD = "";
    }
    /// <summary>
    /// 获取访客机操作员信息返回结果
    /// </summary>
    public class QueryVistorOperatorRes : ResponseInfo
    {
        /// <summary>
        /// 操作员信息
        /// </summary>
        public VistorOperatorInfo Operator = new VistorOperatorInfo();
    }
}
