using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 提交取凭证的记录请求参数
    /// </summary>
    public class PostPickVoucherRecordReq:RequestInfo
    {
        /// <summary>
        /// 第三方返回的GUID
        /// </summary>
        public string RecordGUID = "";
        /// <summary>
        /// 取票时间
        /// </summary>
        public DateTime PickTime = DateTime.Now;
        /// <summary>
        /// 取票抓拍的图片
        /// </summary>
        public string PickImageUrl = "";
    }
    /// <summary>
    /// 提交取凭证的记录返回内容
    /// </summary>
    public class PostPickVoucherRecordRes : ResponseInfo
    {
    }
}
