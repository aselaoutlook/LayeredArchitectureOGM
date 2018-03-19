using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Goals
{
    public class GoalsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Goals";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Goals_default",
                "Goals/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}