using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Core
{
    public static class ResourceExtensions
    {
        public static void JavascriptStrings(string resource)
        {
            var resourceManager = new ResourceManager("Resources." + resource, Assembly.Load("App_GlobalResources"));

            ResourceSet defaultSet = resourceManager.GetResourceSet
                (CultureInfo.GetCultureInfo("en"), true, true);
            ResourceSet resourceSet = resourceManager.GetResourceSet
                (CultureInfo.CurrentCulture, true, true);

            var resourceBaseName = resourceManager.BaseName;
            var jsonObjectName = resourceBaseName.Substring(resourceBaseName.LastIndexOf(".") + 1);

            StringBuilder sb = new StringBuilder();
            sb.Append(jsonObjectName);
            sb.Append("={");
            foreach (DictionaryEntry dictionaryEntry in resourceSet)
            {
                if (dictionaryEntry.Value is string)
                {
                    string value = resourceSet.GetString
                    ((string)dictionaryEntry.Key) ?? (string)dictionaryEntry.Value;
                    sb.AppendFormat("\"{0}\":\"{1}\",", dictionaryEntry.Key, EncodeValue(value));
                }
            }

            string script = sb.ToString();
            if (!string.IsNullOrEmpty(script))
                script = script.Remove(script.Length - 1);

            script += "};";

            JavaScriptResult result = new JavaScriptResult { Script = script };
            System.IO.File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~\Scripts\" + resource + ".js"), result.Script);
        }

        static string EncodeValue(string value)
        {
            value = (value).Replace("\"", "\\\"").Replace('{', '[').Replace('}', ']');
            value = value.Trim();
            value = System.Text.RegularExpressions.Regex.Replace(value, @"\s", " ");
            return value;
        }
    }
}