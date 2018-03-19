using System.ComponentModel.Composition;
using System.Web.Mvc;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.ClientSite.Core;

namespace FCL.Cockerham.Ogsm.ClientSite.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AuditController : ViewControllerBase
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
