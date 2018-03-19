using FCL.Cockerham.Ogsm.ClientSite.Core;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.CompanySetup.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StateUiController : ViewControllerBase
    {
        // GET: CompanySetup/StateUi
        public ActionResult Index()
        {
            return View();
        }
    }
}