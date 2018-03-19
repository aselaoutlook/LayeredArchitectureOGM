using System.ComponentModel.Composition;
using System.Web.Mvc;
using FCL.Cockerham.Ogsm.ClientSite.Core;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.ActionPlanSetup.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActionPlanUiController :  ViewControllerBase
    {
        // GET: ActionPlanSetup/ActionPlanUi
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetActionPlanGridUi()
        {
            return PartialView("_ActionPlanGrid");
        }

        public PartialViewResult GetActionPlanCreateUi()
        {
            return PartialView("_CreateActionPlan");
        }
    }
}