using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Strategy
{
    public class StrategyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Strategy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Strategy_default",
                "Strategy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}