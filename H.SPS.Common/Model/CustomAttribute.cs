using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    public class AddDeleteableAttribute:Attribute
    {
        public bool IsAddDeleteable = false;
        public AddDeleteableAttribute(bool isAddDeleteable)
        {
            IsAddDeleteable = isAddDeleteable;
        }
    }

}
