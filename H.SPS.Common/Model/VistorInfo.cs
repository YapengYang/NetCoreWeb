using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 访客登记信息，姓名、证件、被放人、日期、随行人员
    /// </summary>
    public class VistorInfo
    {
        /// <summary>
        /// 申请记录的GUID
        /// </summary>
        public string ApplyGuid = "";
        /// <summary>
        /// 访客姓名
        /// </summary>
        public string UserName = "";//姓名
        /// <summary>
        /// 证件类型，0为II代身份证
        /// </summary>
        public int IdentifyType = 0;
        /// <summary>
        /// 访客身份证
        /// </summary>
        public string IDNO = "";//身份证号
        /// <summary>
        /// 身份证地址
        /// </summary>
        public string Address = "";
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex = "男";
        /// <summary>
        /// 访客手机号
        /// </summary>
        public string Mobile = "";
        /// <summary>
        /// 人像图集（一般只有一个）
        /// </summary>
        public List<string> ImageUrls = new List<string>();//人像图片路径（相对路径）
        /// <summary>
        /// 被访人姓名
        /// </summary>
        public string VistorPersonName = "";
        /// <summary>
        /// 被访人手机
        /// </summary>
        public string VistorPersonMobile = "";
        /// <summary>
        /// 被访人部门
        /// </summary>
        public string VistorDeptName = "";
        /// <summary>
        /// 被访人的GUID
        /// </summary>
        public string VistorPersonGUID = "";
        /// <summary>
        /// 随行人数
        /// </summary>
        public int EntourageCount = 0;//随行人事
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string CarNO = "";
        /// <summary>
        /// 来访事由
        /// </summary>
        public string VistorReason = "";
        /// <summary>
        /// 来访日期
        /// </summary>
        public DateTime VistorDateFrom = DateTime.Now;
        /// <summary>
        /// 预计离开时间
        /// </summary>
        public DateTime VistorDateTo = DateTime.Now;
        /// <summary>
        /// 访问开始时间
        /// </summary>
        public string VistorTimeFrom = "08:00";
        /// <summary>
        /// 访问结束时间
        /// </summary>
        public string VistorTimeTo="20:00";
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime ApplyDate = DateTime.Now;

    }
}
