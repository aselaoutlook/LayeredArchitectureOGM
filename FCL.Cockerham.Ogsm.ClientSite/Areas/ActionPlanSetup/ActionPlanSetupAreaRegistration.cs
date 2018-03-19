using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.ActionPlanSetup
{
    public class ActionPlanSetupAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ActionPlanSetup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ActionPlanSetup_default",
                "ActionPlanSetup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}