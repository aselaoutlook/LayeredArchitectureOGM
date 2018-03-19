using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using FCL.Cockerham.Ogsm.Admin.Core;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Admin.Controllers
{
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AdminController : ViewControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IRoleService _roleDomainService { get; set; }

        [Import]
        IPermissionService _permissionDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        IEncryption _encryptor { get; set; }

        [Import]
        IGeneralFunctions _generalFunctions { get; set; }

        [Import]
        INullHandler _nullHandler { get; set; }

        [Import]
        IConfigCaller _configCaller { get; set; }

        [Import]
        IEmailSender _emailSender { get; set; }

        #region USERS
        // GET: Admin
        public ActionResult Index()
        {
            //Null Handlers
            //string stringDecimalValue = "";
            //decimal decimalValue;
            //decimalValue = NullHandler.AvoidNullDecimal(stringDecimalValue) / 2;

            //Set Minimumdate
            //DateTime dt = NullHandler.SetMinimumdate();

            //Using ConfigCaller
            //string smtp = ConfigCaller.SMTPPort;

            //Using Email
            //EmailMessage msg = new EmailMessage();
            //EmailSender.SendEmail(msg);

            //Using Resources files
            //var UserAlreadyExist = Resources.SystemMessages.UserAlreadyExist;
            //ModelState.AddModelError(string.Empty, UserAlreadyExist);

            ICollection<UserDto> _users = _userDomainService.GetAllUsers(_dataRepositoryFactory);
            return View(_users);
        }

        public ViewResult UserDetails(int id)
        {
            UserDto user = _userDomainService.GetUserWithRoleByUserId(id, _dataRepositoryFactory);
            SetViewBagData(id);
            return View(user);
        }

        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserCreate(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                var UsernameBlank = Resources.SystemMessages.UsernameBlank;
                ModelState.AddModelError(string.Empty, UsernameBlank);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    bool userExistsInTable = _userDomainService.CheckUserExistByUsername(user.UserName, _dataRepositoryFactory);

                    UserDto _user = null;
                    if (userExistsInTable)
                    {
                        _user = _userDomainService.GetUserByUsername(user.UserName, _dataRepositoryFactory);

                        if (_user != null)
                        {
                            if (_user.IsActive)
                            {
                                var UserAlreadyExist = Resources.SystemMessages.UserAlreadyExist;
                                ModelState.AddModelError(string.Empty, UserAlreadyExist);
                            }
                            else
                            {
                                _user.IsActive = false;
                                _user.LastLoggedOn = DateTime.Now;
                                _userDomainService.UpdateUser(_user, _dataRepositoryFactory);
                                return RedirectToAction("Index");
                            }
                        }
                    }
                    else
                    {
                        _user = new UserDto
                        {
                            UserName = user.UserName,
                            LastName = user.LastName,
                            FirstName = user.FirstName,
                            Email = user.Email
                        };

                        if (ModelState.IsValid)
                        {
                            _user.IsActive = false;
                            _user.LastLoggedOn = DateTime.Now;

                            _userDomainService.CreateUser(_user, _dataRepositoryFactory);
                            return RedirectToAction("Index");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult UserEdit(int id)
        {
            UserDto user = _userDomainService.GetUserWithRoleByUserId(id, _dataRepositoryFactory);
            SetViewBagData(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult UserEdit(UserDto user)
        {
            if (user != null)
            {
                try
                {
                    _userDomainService.UpdateUser(user, user.UserId, _dataRepositoryFactory);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
            }
            return RedirectToAction("UserDetails", new RouteValueDictionary(new { id = user.UserId }));
        }

        [HttpPost]
        public ActionResult UserDetails(UserDto user)
        {
            if (user.UserName == null)
            {
                var ErrUsernameInvalid = Resources.SystemMessages.ErrUsernameInvalid;
                ModelState.AddModelError(string.Empty, ErrUsernameInvalid);
            }

            if (ModelState.IsValid)
            {
                user.IsActive = user.IsActive;
                user.LastLoggedOn = DateTime.Now;
                _userDomainService.UpdateUser(user, _dataRepositoryFactory);
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult DeleteUserRole(int id, int userId)
        {
            UserDto updatedUser = _userDomainService.DeleteUserRole(id, userId, _roleDomainService, _dataRepositoryFactory);
            return RedirectToAction("UserDetails", "Admin", new { id = userId });
        }

        [HttpGet]
        public PartialViewResult Filter4Users(string surname)
        {
            return PartialView("_ListUserTable", GetFilteredUserList(surname));
        }

        private IEnumerable<UserDto> GetFilteredUserList(string _surname)
        {
            IUserRepository UserService = _dataRepositoryFactory.GetUserRepository();
            IEnumerable<UserDto> ret = null;
            try
            {
                if (string.IsNullOrEmpty(_surname))
                {
                    ret = _userDomainService.GetAllUsers(_dataRepositoryFactory);
                }
                else
                {
                    ret = _userDomainService.GetFilteredUserListBySurname(_surname, _dataRepositoryFactory);
                }
            }
            catch
            {
                return null;
            }

            return ret;
        }

        [HttpGet]
        public PartialViewResult FilterReset()
        {
            ICollection<UserDto> _users = _userDomainService.GetAllUsers(_dataRepositoryFactory);
            return PartialView("_ListUserTable", _users);
        }

        [HttpGet]
        public PartialViewResult DeleteUserReturnPartialView(int userId)
        {
            try
            {
                UserDto user = _userDomainService.GetUserByUserId(userId, _dataRepositoryFactory);
                if (user != null)
                {
                    user.IsActive = false;
                    user.UserId = user.UserId;
                    user.LastLoggedOn = DateTime.Now;
                    _userDomainService.UpdateUser(user, _dataRepositoryFactory);
                }
            }
            catch
            {
                return null;
            }

            return this.FilterReset();
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteUserRoleReturnPartialView(int roleId, int userId)
        {
            UserDto updatedUser = _userDomainService.DeleteUserRole(roleId, userId, _roleDomainService, _dataRepositoryFactory);

            SetViewBagData(userId);
            return PartialView("_ListUserRoleTable", updatedUser);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddUserRoleReturnPartialView(int id, int userId)
        {
            UserDto _updatedUser = _userDomainService.AddUserRole(id, userId, _roleDomainService, _dataRepositoryFactory);
            SetViewBagData(userId);
            return PartialView("_ListUserRoleTable", _updatedUser);
        }
        #endregion

        #region ROLES
        public ActionResult RoleIndex()
        {
            return View(_roleDomainService.GetAllRoles(_dataRepositoryFactory).OrderBy(r => r.RoleName));
        }

        public ViewResult RoleDetails(int id)
        {
            RoleDto role = _roleDomainService.GetRoleWithPermissionByRoleId(id, _dataRepositoryFactory);
            ViewBag.UserId = new SelectList(_userDomainService.GetActiveUsers(_dataRepositoryFactory), "Id", "Username");
            ViewBag.RoleId = id;

            ViewBag.PermissionId = new SelectList(_permissionDomainService.GetAllPermission(_dataRepositoryFactory).OrderBy(p => p.PermissionDescription), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();

            return View(role);
        }

        public ActionResult RoleCreate()
        {
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View();
        }

        [HttpPost]
        public ActionResult RoleCreate(RoleDto role)
        {
            if (role.RoleDescription == null)
            {
                ModelState.AddModelError("Role Description", "Role Description must be entered");
            }

            if (ModelState.IsValid)
            {
                _roleDomainService.CreateRole(role, _dataRepositoryFactory);
                return RedirectToAction("RoleIndex");
            }
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View(role);
        }


        public ActionResult RoleEdit(int id)
        {
            RoleDto role = _roleDomainService.GetRoleWithDifinedNavigationByRoleId(id, "Users, Permissions", _dataRepositoryFactory);

            ViewBag.UserId = new SelectList(_userDomainService.GetActiveUsers(_dataRepositoryFactory), "UserId", "Username");
            ViewBag.RoleId = id;

            ViewBag.PermissionId = new SelectList(_permissionDomainService.GetAllPermission(_dataRepositoryFactory).OrderBy(p => p.PermissionDescription), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();

            return View(role);
        }

        [HttpPost]
        public ActionResult RoleEdit(RoleDto role)
        {
            if (string.IsNullOrEmpty(role.RoleDescription))
            {
                ModelState.AddModelError("Role Description", "Role Description must be entered");
            }

            if (ModelState.IsValid)
            {
                _roleDomainService.UpdateRole(role, _dataRepositoryFactory);
                return RedirectToAction("RoleDetails", new RouteValueDictionary(new { id = role.RoleId }));
            }

            ViewBag.UserId = new SelectList(_userDomainService.GetActiveUsers(_dataRepositoryFactory), "UserId", "Username");

            ViewBag.PermissionId = new SelectList(_permissionDomainService.GetAllPermission(_dataRepositoryFactory).OrderBy(p => p.PermissionDescription), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View(role);
        }


        public ActionResult RoleDelete(int id)
        {
            _roleDomainService.DeleteRole(id, _dataRepositoryFactory);
            return RedirectToAction("RoleIndex");
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteUserFromRoleReturnPartialView(int id, int userId)
        {
            RoleDto _role = _roleDomainService.DeleteRoleUser(id, userId, _userDomainService, _dataRepositoryFactory);
            return PartialView("_ListUsersTable4Role", _role);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddUser2RoleReturnPartialView(int id, int userId)
        {
            RoleDto _role = _roleDomainService.AddRoleUser(id, userId, _userDomainService, _dataRepositoryFactory);
            return PartialView("_ListUsersTable4Role", _role);
        }

        #endregion

        #region PERMISSIONS

        public ViewResult PermissionIndex()
        {
            IEnumerable<PermissionDto> permissions = _permissionDomainService.GetPermissionListWithDifinedNavigation("Roles.Users", _dataRepositoryFactory);
            return View(permissions);
        }

        public ViewResult PermissionDetails(int id)
        {
            PermissionDto permission = _permissionDomainService.GetPermissionWithDefinedNavigationByPermissionId(id, "Roles", _dataRepositoryFactory);            
            return View(permission);
        }

        public ActionResult PermissionCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PermissionCreate(PermissionDto permission)
        {
            if (permission.PermissionDescription == null)
            {
                ModelState.AddModelError("Permission Description", "Permission Description must be entered");
            }

            if (ModelState.IsValid)
            {
                _permissionDomainService.CreatePermission(permission, _dataRepositoryFactory);
                return RedirectToAction("PermissionIndex");
            }
            return View(permission);
        }

        public ActionResult PermissionEdit(int id)
        {
            PermissionDto permission = _permissionDomainService.GetPermissionWithDefinedNavigationByPermissionId(id, "Roles", _dataRepositoryFactory);
            ViewBag.RoleId = new SelectList(_roleDomainService.GetAllRoles(_dataRepositoryFactory).OrderBy(r => r.RoleName), "RoleId", "RoleName");
            return View(permission);
        }

        [HttpPost]
        public ActionResult PermissionEdit(PermissionDto permission)
        {
            if (ModelState.IsValid)
            {
                _permissionDomainService.UpdatePermission(permission, _dataRepositoryFactory);
                return RedirectToAction("PermissionDetails", new RouteValueDictionary(new { id = permission.PermissionId }));
            }
            return View(permission);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult PermissionDelete(int id)
        {
            _permissionDomainService.DeletePermission(id, _dataRepositoryFactory);
            return RedirectToAction("PermissionIndex");
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddPermission2RoleReturnPartialView(int id, int permissionId)
        {
            RoleDto _role = _roleDomainService.AddRole2Permission(id, permissionId, _permissionDomainService, _dataRepositoryFactory);
            return PartialView("_ListPermissions", _role);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddAllPermissions2RoleReturnPartialView(int id)
        {
            RoleDto role = _roleDomainService.AddAllRoles2Permission(id, _dataRepositoryFactory);
            return PartialView("_ListPermissions", role);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeletePermissionFromRoleReturnPartialView(int id, int permissionId)
        {
            RoleDto _updatedRole = _roleDomainService.DeletePermissionFromRole(id, permissionId, _permissionDomainService, _dataRepositoryFactory);
            return PartialView("_ListPermissions", _updatedRole);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteRoleFromPermissionReturnPartialView(int id, int permissionId)
        {
            PermissionDto _updatedPermission = _permissionDomainService.DeleteRoleFromPermission(id, permissionId, _roleDomainService, _dataRepositoryFactory);
            return PartialView("_ListRolesTable4Permission", _updatedPermission);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddRole2PermissionReturnPartialView(int permissionId, int roleId)
        {
            PermissionDto _updatedPermission = _permissionDomainService.AddRole2Permission(permissionId, roleId, _roleDomainService, _dataRepositoryFactory);
            return PartialView("_ListRolesTable4Permission", _updatedPermission);
        }

        public ActionResult PermissionsImport()
        {
            var controllerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t != null
                    && t.IsPublic
                    && t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
                    && !t.IsAbstract
                    && typeof(IController).IsAssignableFrom(t));

            Dictionary<Type, IEnumerable<MethodInfo>> controllerMethods = controllerTypes.ToDictionary(controllerType => controllerType,
                    controllerType => controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType)));
            
            _permissionDomainService.ImportPermissions(controllerMethods, _dataRepositoryFactory);
            return RedirectToAction("PermissionIndex");
        }
        #endregion

        private void SetViewBagData(int userId)
        {
            ViewBag.UserId = userId;
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            ViewBag.RoleId = new SelectList(_roleDomainService.GetAllRoles(_dataRepositoryFactory).OrderBy(r => r.RoleName), "RoleId", "RoleName");
        }

        public List<SelectListItem> List_boolNullYesNo()
        {
            var retVal = new List<SelectListItem>();
            try
            {
                retVal.Add(new SelectListItem { Text = "Not Set", Value = null });
                retVal.Add(new SelectListItem { Text = "Yes", Value = bool.TrueString });
                retVal.Add(new SelectListItem { Text = "No", Value = bool.FalseString });
            }
            catch { }
            return retVal;
        }
    }
}