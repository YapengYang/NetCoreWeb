using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 访客审批记录
    /// </summary>
    public class VistorApproveResult
    {
        /// <summary>
        /// //第三方系统的GUID
        /// </summary>
        public string GUID = "";
        /// <summary>
        /// 申请时的提交的GUID
        /// </summary>
        public string ApplyGuid = "";
        /// <summary>
        /// 访客信息
        /// </summary>
        public VistorInfo VistorInfo = new VistorInfo();
        /// <summary>
        /// 审批结果
        /// </summary>
        public EVistorApplyResult Result = EVistorApplyResult.Unknown;
        /// <summary>
        /// 同行二维码
        /// </summary>
        public string QrCode = "";

    }
}
