using System.ComponentModel.Composition;
using System.Web.Mvc;
using FCL.Cockerham.Ogsm.ClientSite.Core;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.DashboardSetup.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DashboardHomeActionPlanUiController : Controller
    {
        // GET: DashboardSetup/DashboardHomeActionPlanUi
        public PartialViewResult Index()
        {
            return PartialView("_Index");
        }
    }
}