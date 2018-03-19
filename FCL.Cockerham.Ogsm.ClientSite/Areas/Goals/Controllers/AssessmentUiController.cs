using FCL.Cockerham.Ogsm.Entities.ViewModel;
using FCL.Cockerham.Ogsm.ClientSite.Core;
using FCL.Cockerham.Ogsm.Entities;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Goals.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AssessmentUiController : ViewControllerBase
    {
        // GET: Goals/AssessmentUi
        public ActionResult Index()
        {
            return View();
        }
    }
}