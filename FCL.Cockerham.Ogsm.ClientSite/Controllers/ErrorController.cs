using FCL.Cockerham.Ogsm.ClientSite.Core;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Controllers
{
    public class ErrorController : ViewControllerBase
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Something went wrong. The error is logged and administrator will look into it.";
            return View();
        }

        public ActionResult NotFound()
        {
            ViewBag.Message = "What you are looking for does not exist. If you think it should, let administrator look into it.";
            return View();
        }

        public ActionResult AccessDenied()
        {
            ViewBag.Message = "You are not authorized to access this area. Please contact administrator if you think you should gain access.";
            return View();
        }
    }
}