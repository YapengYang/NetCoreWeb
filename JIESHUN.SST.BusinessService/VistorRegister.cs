using H.SPS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.BusinessService
{
    public class VistorRegister : IControllerRegister
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Type> GetAll()
        {
            return new List<Type>()
            {
                typeof(VistorService)
            };
        }
    }
}
