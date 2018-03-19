using FCL.Cockerham.Ogsm.Entities.ViewModel;
using FCL.Cockerham.Ogsm.ClientSite.Core;
using FCL.Cockerham.Ogsm.Entities;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.CompanySetup.Controllers
{
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BusinessUnitUiController : ViewControllerBase
    {        
        // GET: CompanySetup-BusinessUnit
        public ActionResult Index()
        {
            return View();
        }

    }
}