using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 提访客申请请求参数
    /// </summary>
    public class PostVistorInfoReq:RequestInfo
    {
        /// <summary>
        /// 访客登记信息
        /// </summary>
        public VistorInfo VistorInfo = new VistorInfo();
    }
    /// <summary>
    /// 提访客申请返回内容
    /// </summary>
    public class PostVistorInfoRes : ResponseInfo
    {
        /// <summary>
        /// 审批结果
        /// </summary>
        public VistorApproveResult ApproveResult = new VistorApproveResult();
    }
}
