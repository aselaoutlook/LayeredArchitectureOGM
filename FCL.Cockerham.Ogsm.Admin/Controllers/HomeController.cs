using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.Admin.Controllers
{
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : BaseController
    {

        public HomeController()
        {
        }
                
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Auditor()
        {
            return RedirectToAction("Index", "Audit");
        }

        // GET: Home
        public ActionResult TemplateEditor()
        {
            return RedirectToAction("Index", "TemplateEditor");
        }
    }
}
