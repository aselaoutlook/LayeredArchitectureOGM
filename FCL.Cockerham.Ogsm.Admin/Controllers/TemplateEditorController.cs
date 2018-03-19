using System.ComponentModel.Composition;
using System.Web.Mvc;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Admin.Core;

namespace FCL.Cockerham.Ogsm.Admin.Controllers
{
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TemplateEditorController : ViewControllerBase
    {
        [Import]
        IUnitOfWork DataRepositoryFactory { get; set; }

        [Import]
        ILoggerService Logger { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
