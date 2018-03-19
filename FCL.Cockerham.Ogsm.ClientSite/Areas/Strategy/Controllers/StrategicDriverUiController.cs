using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCL.Cockerham.Ogsm.ClientSite.Core;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Strategy.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StrategicDriverUiController : ViewControllerBase
    {
        // GET: Strategy/StrategicDriverUi
        public ActionResult Index()
        {
            return View();
        }
    }
}