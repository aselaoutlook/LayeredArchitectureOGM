using FCL.Cockerham.Ogsm.ClientSite.Core;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Owners.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OwnersUiController : ViewControllerBase
    {
        // GET: Owners/OwnersUi
        public ActionResult Index()
        {
            return View();
        }
    }
}