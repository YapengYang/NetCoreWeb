﻿using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    public interface IServiceRegister
    {
        //object Execute(object input);
        List<Type> GetAll();
    }
}
