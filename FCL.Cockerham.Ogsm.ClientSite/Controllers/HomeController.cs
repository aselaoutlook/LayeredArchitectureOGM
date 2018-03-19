using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Collections.Generic;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.ClientSite.Core;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.ClientSite.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : ViewControllerBase
    {
        [Authorize]
        // GET: Dashboard Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "DashboardHomeUi", new { area = "DashboardSetup" });
        }
    }
}
