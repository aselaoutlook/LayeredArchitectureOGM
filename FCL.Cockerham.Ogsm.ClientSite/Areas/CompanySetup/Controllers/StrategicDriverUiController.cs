using FCL.Cockerham.Ogsm.ClientSite.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.CompanySetup.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StrategicDriverUiController : ViewControllerBase
    {
        // GET: CompanySetup/StrategicDriverUi
        public ActionResult Index()
        {
            return View();
        }
    }
}