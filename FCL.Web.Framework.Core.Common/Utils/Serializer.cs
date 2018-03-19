using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace FCL.Web.Framework.Core.Common.Utils
{
    /// <summary>
    /// Serializers for different formats
    /// </summary>
    public static class Serializer
    {
        public static string Json(object source, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(source,Formatting.Indented,settings);
        }

        public static string Xml(object source)
        {
            XmlSerializer serializer = new XmlSerializer(source.GetType());
            StringBuilder result = new StringBuilder();
            using (var writer = XmlWriter.Create(result))
            {
                serializer.Serialize(writer, source);
            }
            return result.ToString();
        }
    }
}
