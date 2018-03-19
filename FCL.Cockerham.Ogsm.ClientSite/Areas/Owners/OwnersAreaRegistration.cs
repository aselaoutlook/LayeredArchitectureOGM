using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Owners
{
    public class OwnersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Owners";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Owners_default",
                "Owners/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}