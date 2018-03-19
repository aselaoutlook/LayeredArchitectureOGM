using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FCL.Web.Framework.Core.Common.Utils
{
    static class DeSerializer
    {
        public static T Json<T>(string source)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }

        public static T Xml<T>(string source) where T : class
        {
            var ser = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(source))
                return (T)ser.Deserialize(sr);
        }
    }
}
