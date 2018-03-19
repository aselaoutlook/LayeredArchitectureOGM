using FCL.Cockerham.Ogsm.Data.Contracts;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.Admin.Controllers
{
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ReportController : Controller
    {
        [Import]
        IUnitOfWork DataRepositoryFactory { get; set; }

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
    }
}