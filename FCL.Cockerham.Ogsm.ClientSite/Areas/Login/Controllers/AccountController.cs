using FCL.Cockerham.Ogsm.ClientSite.Core.Util;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using FCL.Web.Framework.Core.Common.Contracts;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Security;
using System;
using System.Linq;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Login.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountController : Controller
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IStrategicDriverService _strategicDriverDomainService { get; set; }

        [Import]
        IEncryption _encryption { get; set; }

        // GET: Login/Account
        public ActionResult Authenticate()
        {
            return View("Login");
        }

        public ActionResult Validate()
        {
            // Forms Authentication
            string _username = Request.Form["Username"].Trim();
            string _password = Request.Form["Password"].Trim();

            //LoggedInUserDto _user = _userDomainService.GetUserForSignInByUsername(_username, _dataRepositoryFactory);
            //string pass = _encryption.DoEncrypt(_password);
            LoggedInUserDto _user = _userDomainService.GetUserForSignInByUsernameAndPassword(_username, _encryption.DoEncrypt(_password), _dataRepositoryFactory);

            if (_user != null)
            {
                if (_user.IsActive)
                {
                    FormsAuthentication.SetAuthCookie(_user.UserName, false);
                    Session.Add("LoggedInUser", _user);
                    Role IsClientAdmin = _user.Roles.Where(i => i.RoleName.Equals(Constants.SESSION_CLIENT_ADMIN)).FirstOrDefault();

                    if (IsClientAdmin != null)
                    {
                        Session.Add("UserType", Constants.SESSION_CLIENT_ADMIN);
                    }
                    else
                    {
                        IEnumerable<StrategicDriverDto> _strategicDrivers = new List<StrategicDriverDto>();
                        Role IsEmployee = _user.Roles.Where(i => i.RoleName.Equals(Constants.SESSION_EMPLOYEE)).FirstOrDefault();

                        if (IsEmployee != null)
                        {                            
                            _strategicDrivers = _strategicDriverDomainService.GetStrategicDriverByStrategyOwnerId(_user.UserId, _user.OrganizationId, _dataRepositoryFactory);
                            if (_strategicDrivers.Count() > 0)
                            {
                                Session.Add("UserType", Constants.SESSION_STRATEGY_OWNER);
                            }

                            //Domain.EmployeeAG IsStrategyOwner = emp.Employees3[0].EmployeeAGs.Where(x => x.IsStrategyOwner.Equals(true)).FirstOrDefault();
                        }
                    }

                    //if (_user.Roles.Contains(Constants.SESSION_CLIENT_ADMIN))
                    //{
                    //    if (_user.OrganizationAdmins.Count > 0)
                    //    {
                    //        SessionManager.Store("OrgId", user.OrganizationAdmins[0].Organization.Id);
                    //        if (_user.OrganizationAdmins[0].Organization.Theme != null)
                    //        {
                    //            SessionManager.Store(Constants.SESSION_THEME_NAME, user.OrganizationAdmins[0].Organization.Theme.Name);
                    //        }
                    //        else
                    //        {
                    //            SessionManager.Store(Constants.SESSION_THEME_NAME, ConfigCaller.DefaultTheme);
                    //        }
                    //    }
                    //}

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    return View("Login");
                }
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