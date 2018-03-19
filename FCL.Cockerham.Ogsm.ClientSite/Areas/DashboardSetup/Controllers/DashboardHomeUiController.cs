using System.ComponentModel.Composition;
using System.Web.Mvc;
using FCL.Cockerham.Ogsm.ClientSite.Core;
using FCL.Cockerham.Ogsm.ClientSite.Core.Filters;
using FCL.Cockerham.Ogsm.ClientSite.Core.Util;


namespace FCL.Cockerham.Ogsm.ClientSite.Areas.DashboardSetup.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    //[FclAuthorize(Roles=Constants.SESSION_CLIENT_ADMIN)]
    public class DashboardHomeUiController : ViewControllerBase
    {
        // GET: DashboardSetup/DashboardHomeUi
        public ActionResult Index()
        {
            return View();
        }
    }
}