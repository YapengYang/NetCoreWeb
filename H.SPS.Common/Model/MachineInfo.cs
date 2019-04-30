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
    /// 机器信息
    /// </summary>
    [KnownType(typeof(MachineInfoDesktop))]
    [KnownType(typeof(MachineInfoVertical))]
    public partial class MachineInfo
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("名称")]
        public string Name = "自助终端设备";
        [Required]
        [DisplayName("IP")]
        public string IP = "";
        [Required]
        [DisplayName("自助式")]
        public bool IsSelfMachine = true;
        [Required]
        [DisplayName("带键盘")]
        public bool IsContainsKeyboard = false;
        [Required]
        [DisplayName("硬件类型")]
        public EDeviceHardwareType DeviceHardwareType = EDeviceHardwareType.Boshite;

        //[DisplayName("扩展参数")]
        //public List<object> Extensions = new List<object>();
    }
    /// <summary>
    /// 立式设备
    /// </summary>
    public class MachineInfoVertical: MachineInfo
    {
        public MachineInfoVertical()
        {
            base.Name = "立式";
            base.IsSelfMachine = false;
            base.IsContainsKeyboard = false;
            
        }
    }
    /// <summary>
    /// 台式设备
    /// </summary>
    public class MachineInfoDesktop : MachineInfo
    {
        public MachineInfoDesktop()
        {
            base.Name = "台式";
            base.IsSelfMachine = true;
            base.IsContainsKeyboard = true;
        }
    }
}
