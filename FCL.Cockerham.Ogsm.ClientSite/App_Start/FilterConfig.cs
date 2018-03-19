using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
