using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;
using FCL.Web.Framework.Core.Common.Encryption;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FCL.Cockerham.Ogsm.Admin.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountController : Controller
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        // GET: Login/Account
        [AllowAnonymous]
        public ActionResult Authenticate()
        {
            return View("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Validate()
        {
            // Forms Authentication
            string _username = Request.Form["Username"].Trim();
            string _password = Request.Form["Password"].Trim();

            Encryption encryption = new Encryption();
            LoggedInUserDto _user = _userDomainService.GetUserForSignInByUsernameAndPassword(_username, _password, _dataRepositoryFactory);

            if (_user != null)
            {
                FormsAuthentication.SetAuthCookie("OGSM-ADMIN", false);
                Session.Add("LoggedInUser", _user);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["LoggedInUser"] = "";
            Session.Abandon();
            return View("Login");
        }
    }
}