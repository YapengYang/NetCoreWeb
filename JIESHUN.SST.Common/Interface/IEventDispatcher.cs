using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace H.SPS.Common
{
    public interface IEventDispatcher
    {
        void Init();
        bool Notify(string msg);
        void Close();
    }
}
