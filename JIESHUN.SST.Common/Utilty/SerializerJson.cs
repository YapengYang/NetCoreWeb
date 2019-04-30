using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace H.SPS.Common
{
    /// <summary>
    /// 对Newtonsoft.Json做二次封装，避免程序中到处引用Newtonsoft.Json
    /// </summary>
    public class SerializerJson
    {
        public static string SerializeObject(object t)
        {
            // Creates serializer.
            return JsonConvert.SerializeObject(t);

        }

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static object DeserializeObject(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }
    }
}
