using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.DashboardSetup
{
    public class DashboardSetupAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DashboardSetup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DashboardSetup_default",
                "DashboardSetup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}