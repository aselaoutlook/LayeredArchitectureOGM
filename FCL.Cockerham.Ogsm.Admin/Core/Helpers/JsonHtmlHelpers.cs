using System.Web;
using System.Web.Mvc;
using FCL.Cockerham.Ogsm.Admin.Core.Util;

namespace FCL.Cockerham.Ogsm.Admin.Core.Helpers
{
    public static class JsonHtmlHelpers
    {
        public static IHtmlString JsonFor<T>(this HtmlHelper helper, T obj)
        {
            return helper.Raw(obj.ToJson());
        }
    }
}