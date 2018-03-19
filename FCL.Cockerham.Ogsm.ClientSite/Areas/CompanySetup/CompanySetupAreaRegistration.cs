using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.CompanySetup
{
    public class CompanySetupAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CompanySetup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CompanySetup_default",
                "CompanySetup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}