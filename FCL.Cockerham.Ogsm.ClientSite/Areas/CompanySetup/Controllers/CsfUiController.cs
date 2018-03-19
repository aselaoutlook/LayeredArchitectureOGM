using FCL.Cockerham.Ogsm.ClientSite.Core;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.CompanySetup.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CsfUiController : ViewControllerBase
    {
        // GET: CompanySetup/CsfUi
        public ActionResult Index()
        {
            return View();
        }
    }
}