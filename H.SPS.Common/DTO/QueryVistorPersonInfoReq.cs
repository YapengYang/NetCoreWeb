using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 按条件模糊查询被放人请求参数
    /// </summary>
    public class QueryVistorPersonInfoReq:RequestInfo
    {
        /// <summary>
        /// 0:手机 1:姓名
        /// </summary>
        public int RequestType = 0;
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile = "";
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name = "";
    }
    /// <summary>
    /// 按条件查询被放人返回结果
    /// </summary>
    public class QueryVistorPersonInfoRes : ResponseInfo
    {
        /// <summary>
        /// 相似的人事资料
        /// </summary>
        public List<VistorPersonInfo> PersonList = new List<VistorPersonInfo>();
    }
}
