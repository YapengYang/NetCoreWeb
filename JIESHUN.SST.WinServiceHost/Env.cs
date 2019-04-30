using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.WinServiceHost
{
    public  class Env
    {
        static Env _env;
        public static Env Instance
        {
            get
            {
                if(_env==null)
                {
                    throw new Exception("环境未初始化，禁止调用Env.Instance！");
                }
                return _env;
            }
            set
            {
                _env = value;
            }
        }
        public IServiceProvider ApplicationServices;
        public ILoggerFactory LoggerFactory;
    }
}
