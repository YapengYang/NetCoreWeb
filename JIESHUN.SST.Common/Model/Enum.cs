using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
namespace H.SPS.Common
{
    /// <summary>
    /// 访客机硬件类型
    /// </summary>
    public enum EDeviceHardwareType
    {
        /// <summary>
        /// 博士特
        /// </summary>
        [DisplayName("博时特")]
        Boshite,
        /// <summary>
        /// 德天
        /// </summary>
        [DisplayName("德天")]
        Detian
    }

    /// <summary>
    /// 申请结果，未处理、已通过/已拒绝
    /// </summary>
    public enum EVistorApplyResult
    {
        /// <summary>
        /// 未审批
        /// </summary>
        Unknown,
        /// <summary>
        /// 已通过
        /// </summary>
        Accept,
        /// <summary>
        /// 已拒绝
        /// </summary>
        Reject,
    }
}
