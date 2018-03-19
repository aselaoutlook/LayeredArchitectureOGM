using System.ComponentModel.Composition;
using System.Web.Mvc;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Data.Contracts;

namespace FCL.Cockerham.Ogsm.Admin.Controllers
{
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AuditController : BaseController
    {
        [Import]
        IUnitOfWork DataRepositoryFactory { get; set; }
         
        // GET: Home
        public ActionResult Index()
        {
            IAuditRepository AuditService = DataRepositoryFactory.GetAuditRepository();
            return View(AuditService.AllAudits());
        }

    }


}
