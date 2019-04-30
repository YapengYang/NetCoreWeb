using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace H.SPS.Common
{
    /// <summary>
    /// 系统信息
    /// </summary>
    public class SystemInfo
    {
        [Required]
        [DisplayName("公司名称")]
        public string CompanyName = "捷顺科技";

        [DisplayName("系统参数")]
        public List<object> Extensions = new List<object>();

        
        [AddDeleteable(true)]
        [DisplayName("设备列表")]
        public List<MachineInfo> MachineList = new List<MachineInfo>();

        //[DisplayName("超时时间")]
        //public int TimeOut = 21;

    }

}
