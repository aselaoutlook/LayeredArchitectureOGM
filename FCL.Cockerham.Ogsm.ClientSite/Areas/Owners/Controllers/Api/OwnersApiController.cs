using FCL.Cockerham.Ogsm.ClientSite.Core;
using FCL.Cockerham.Ogsm.ClientSite.Core.Util;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using FCL.Cockerham.Ogsm.Entities.ViewModel;
using FCL.Web.Framework.Core.Common.Contracts;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Owners.Controllers.Api
{
    /// <summary>
    /// Goal Category Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OwnersApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IRoleService _roleDomainService { get; set; }
        
        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [Import]
        IEncryption _encryption { get; set; }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/OwnersApi/GetLoggedInUserDetailsForHeader")]
        public HttpResponseMessage GetLoggedInUserDetailsForHeader()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    HeaderDetailsViewModel headerDetailsVm = new HeaderDetailsViewModel();
                    headerDetailsVm.UserId = LoggedInUser.UserId;
                    headerDetailsVm.FirstName = LoggedInUser.FirstName;
                    headerDetailsVm.LastName = LoggedInUser.LastName;
                    headerDetailsVm.MiddleInitial = LoggedInUser.MiddleInitial;
                    headerDetailsVm.UserName = LoggedInUser.UserName;
                    if (!string.IsNullOrEmpty(LoggedInUser.Image))
                    {
                        headerDetailsVm.UserImage = SystemResources.UserDefaultImageTempPath + LoggedInUser.Image;
                    }
                    else
                    {
                        headerDetailsVm.UserImage = SystemResources.UserDefaultAvatarImagePath;
                    }

                    headerDetailsVm.RoleName = LoggedInUser.Roles[0].RoleName;
                    headerDetailsVm.CompanyLogo = "Test";//LoggedInUser.Organization.Logo;            

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, headerDetailsVm);
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
                }
            }
            else
            {
                return this.GenarateUnauthorizedServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/OwnersApi/GetActiveGoalOwnersByOrganization")]
        public HttpResponseMessage GetActiveGoalOwnersByOrganization()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<UserDto> _users = _userDomainService.GetActiveGoalOwnersByOrganization(LoggedInUser.Organization.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _users);
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
                }
            }
            else
            {
                return this.GenarateUnauthorizedServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/OwnersApi/GetAllActiveStrategicDriverEmployees")]
        public HttpResponseMessage GetAllActiveStrategicDriverEmployees(long SdId, int pageNo = 1, int pageSize = 50)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    int skip = (pageNo - 1) * pageSize;
                    IEnumerable<UserDto> _users = _userDomainService.GetAllActiveStrategicDriverEmployees(skip, pageSize, SdId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    long totalItemCount = new List<UserDto>(_users).Count;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<UserDto>(_users, 1, 50, totalItemCount));
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
                }
            }
            else
            {
                return this.GenarateUnauthorizedServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/OwnersApi/GetUsersForOwnersSearch")]
        public HttpResponseMessage GetUsersForOwnersSearch(long SdId, string Key)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<UserDto> _users = _userDomainService.GetSearchUserListByKey(Key, LoggedInUser.OrganizationId, SdId, _dataRepositoryFactory);
                    //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _users);
                    long totalItemCount = new List<UserDto>(_users).Count;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<UserDto>(_users, 1, 50, totalItemCount));
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
                }
            }
            else
            {
                return this.GenarateUnauthorizedServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        public HttpResponseMessage Get(int pageNo = 1, int pageSize = 50)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    int skip = (pageNo - 1) * pageSize;
                    long totalItemCount = _userDomainService.GetUserCount(_dataRepositoryFactory);
                    IEnumerable<UserDto> _users = _userDomainService.GetUserList(skip, pageSize, LoggedInUser.Organization.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<UserDto>(_users, pageNo, pageSize, totalItemCount));
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
                }
            }
            else
            {
                return this.GenarateUnauthorizedServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        public HttpResponseMessage Get(long UserId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    UserDto _user = _userDomainService.GetUserByUserId(UserId, _dataRepositoryFactory);

                    if (_user.EmployeeUser.Count == 0)
                    {
                        List<Employee> emptyEmployee = new List<Employee>();
                        _user.EmployeeUser = emptyEmployee;
                    }

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _user);
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
                }
            }
            else
            {
                return this.GenarateUnauthorizedServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        public HttpResponseMessage Post(UserDto user)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {                        
                        user.Password = _encryption.DoEncrypt(user.Password);
                        user.OrganizationId = LoggedInUser.OrganizationId;
                        user.CreatedDate = DateTime.Now;
                        user.UpdatedDate = DateTime.Now;
                        user.LastLoggedOn = DateTime.Now;

                        user.EmployeeUser[0].OrganizationId = LoggedInUser.OrganizationId;
                        user.EmployeeUser[0].CreatedDate = DateTime.Now;
                        user.EmployeeUser[0].UpdatedDate = _nullHandlerService.SetMinimumdate();
                        user.EmployeeUser[0].CreatedBy = LoggedInUser.UserId;

                        user.OwnedEmployeeStrategies[0].OrganizationId = LoggedInUser.OrganizationId;
                        user.OwnedEmployeeStrategies[0].CreatedDate = DateTime.Now;
                        user.OwnedEmployeeStrategies[0].UpdatedDate = _nullHandlerService.SetMinimumdate();
                        user.OwnedEmployeeStrategies[0].CreatedBy = LoggedInUser.UserId;

                        //RoleDto _employeeRole = _roleDomainService.GetRoleByRoleName("Employee", _dataRepositoryFactory);
                        UserDto createdUser = _userDomainService.CreateUser(user, _dataRepositoryFactory);
                        //_userDomainService.AddUserRole(_employeeRole.RoleId, createdUser.UserId, _roleDomainService, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, UserPagedList(1, 50));
                        return response;
                    }
                    else
                    {
                        string errors = ModelStateErrorExtensions.GetModelStateErrorsAsString(ModelState.Values);
                        return this.GenarateInternalServerError(errors);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
                }
            }
            else
            {
                return this.GenarateUnauthorizedServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        public HttpResponseMessage Put(UserDto user)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        UserDto _UpdatingUser = _userDomainService.GetUserByUserIdAsTrackable(user.UserId, _dataRepositoryFactory);

                        _UpdatingUser.FirstName = user.FirstName;
                        _UpdatingUser.MiddleInitial = user.MiddleInitial;
                        _UpdatingUser.LastName = user.LastName;
                        _UpdatingUser.UserName = user.UserName;
                        _UpdatingUser.Roles = new List<Role>();
                        if (_UpdatingUser.Password != user.Password)
                        {
                            _UpdatingUser.Password = _encryption.DoEncrypt(user.Password);
                        }


                        _UpdatingUser.Email = user.Email;
                        _UpdatingUser.Mobile = user.Mobile;
                        _UpdatingUser.IsActive = user.IsActive;

                        if (_UpdatingUser.Image != user.Image)
                        {
                            _UpdatingUser.Image = user.Image;
                        }
                       
                        _UpdatingUser.UpdatedDate = DateTime.Now;

                        if (_UpdatingUser.EmployeeUser.Count != 0)
                        {
                            _UpdatingUser.EmployeeUser[0].BusinessPhone = user.EmployeeUser[0].BusinessPhone;
                            _UpdatingUser.EmployeeUser[0].Country = user.EmployeeUser[0].Country;
                            _UpdatingUser.EmployeeUser[0].AddressOne = user.EmployeeUser[0].AddressOne;
                            _UpdatingUser.EmployeeUser[0].AddressTwo = user.EmployeeUser[0].AddressTwo;
                            _UpdatingUser.EmployeeUser[0].City = user.EmployeeUser[0].City;
                            _UpdatingUser.EmployeeUser[0].State = user.EmployeeUser[0].State;
                            _UpdatingUser.EmployeeUser[0].Zip = user.EmployeeUser[0].Zip;
                            _UpdatingUser.EmployeeUser[0].UpdatedBy = LoggedInUser.UserId;
                            _UpdatingUser.EmployeeUser[0].UpdatedDate = DateTime.Now;
                            _UpdatingUser.EmployeeUser[0].IsViewOnly = user.EmployeeUser[0].IsViewOnly;
                            _UpdatingUser.EmployeeUser[0].IsActionPlanOwner = user.EmployeeUser[0].IsActionPlanOwner;
                            _UpdatingUser.EmployeeUser[0].IsStrategicDriverOwner = user.EmployeeUser[0].IsStrategicDriverOwner;
                            _UpdatingUser.EmployeeUser[0].IsGoalOwner = user.EmployeeUser[0].IsGoalOwner;
                            _UpdatingUser.EmployeeUser[0].IsBusinessUnitLead = user.EmployeeUser[0].IsBusinessUnitLead;

                        }
                        else
                        {
                            _UpdatingUser.EmployeeUser.Add(new Employee());
                            _UpdatingUser.EmployeeUser[0].OrganizationId = LoggedInUser.OrganizationId;

                            if (user.EmployeeUser.Count != 0)
                            {
                                _UpdatingUser.EmployeeUser[0].BusinessPhone = user.EmployeeUser[0].BusinessPhone;
                                _UpdatingUser.EmployeeUser[0].Country = user.EmployeeUser[0].Country;
                                _UpdatingUser.EmployeeUser[0].AddressOne = user.EmployeeUser[0].AddressOne;
                                _UpdatingUser.EmployeeUser[0].AddressTwo = user.EmployeeUser[0].AddressTwo;
                                _UpdatingUser.EmployeeUser[0].City = user.EmployeeUser[0].City;
                                _UpdatingUser.EmployeeUser[0].State = user.EmployeeUser[0].State;
                                _UpdatingUser.EmployeeUser[0].Zip = user.EmployeeUser[0].Zip;
                                _UpdatingUser.EmployeeUser[0].IsViewOnly = user.EmployeeUser[0].IsViewOnly;
                                _UpdatingUser.EmployeeUser[0].IsActionPlanOwner = user.EmployeeUser[0].IsActionPlanOwner;
                                _UpdatingUser.EmployeeUser[0].IsStrategicDriverOwner = user.EmployeeUser[0].IsStrategicDriverOwner;
                                _UpdatingUser.EmployeeUser[0].IsGoalOwner = user.EmployeeUser[0].IsGoalOwner;
                                _UpdatingUser.EmployeeUser[0].IsBusinessUnitLead = user.EmployeeUser[0].IsBusinessUnitLead;

                                _UpdatingUser.EmployeeUser[0].CreatedDate = DateTime.Now;
                                _UpdatingUser.EmployeeUser[0].UpdatedDate = _nullHandlerService.SetMinimumdate();
                                _UpdatingUser.EmployeeUser[0].CreatedBy = LoggedInUser.UserId;
                                _UpdatingUser.EmployeeUser[0].UpdatedBy = LoggedInUser.UserId;
                                _UpdatingUser.EmployeeUser[0].UpdatedDate = _nullHandlerService.SetMinimumdate();
                            }
                        }


                        if (user.OwnedEmployeeStrategies != null)
                        {
                            if (!(_UpdatingUser.EmployeeUser[0].EmployeeStrategies.Contains(user.OwnedEmployeeStrategies[0])))
                            {
                                EmployeeStrategy _employeeStrategy = new EmployeeStrategy();

                                _employeeStrategy.EmployeeId = _UpdatingUser.EmployeeUser[0].EmployeeId;
                                _employeeStrategy.UserId = _UpdatingUser.EmployeeUser[0].UserId;
                                _employeeStrategy.StrategicDriverId = user.OwnedEmployeeStrategies[0].StrategicDriverId;
                                _employeeStrategy.IsViewOnly = user.OwnedEmployeeStrategies[0].IsViewOnly;
                                _employeeStrategy.IsActionPlanOwner = user.OwnedEmployeeStrategies[0].IsActionPlanOwner;
                                _employeeStrategy.IsStrategicDriverOwner = user.OwnedEmployeeStrategies[0].IsStrategicDriverOwner;
                                _employeeStrategy.IsGoalOwner = user.OwnedEmployeeStrategies[0].IsGoalOwner;
                                _employeeStrategy.IsBusinessUnitLead = user.OwnedEmployeeStrategies[0].IsBusinessUnitLead;
                                _employeeStrategy.IsActive = user.OwnedEmployeeStrategies[0].IsActive;
                                _employeeStrategy.OrganizationId = LoggedInUser.OrganizationId;
                                _employeeStrategy.CreatedDate = DateTime.Now;
                                _employeeStrategy.UpdatedDate = _nullHandlerService.SetMinimumdate();
                                _employeeStrategy.CreatedBy = LoggedInUser.UserId;

                                _UpdatingUser.EmployeeUser[0].EmployeeStrategies.Add(_employeeStrategy);
                            }
                        }

                        UserDto updatedUser = _userDomainService.UpdateUser(_UpdatingUser, _UpdatingUser.UserId, _dataRepositoryFactory);

                        // RoleDto _employeeRole = _roleDomainService.GetRoleByRoleName("Employee", _dataRepositoryFactory);
                        //_roleDomainService.UpdateRole(_employeeRole, _dataRepositoryFactory);

                        int pageNo = 1;
                        int pageSize = 50;
                        long sdId = Convert.ToInt64(user.OwnedEmployeeStrategies[0].StrategicDriverId);

                        int skip = (pageNo - 1) * pageSize;
                        IEnumerable<UserDto> _users = _userDomainService.GetAllActiveStrategicDriverEmployees(skip, pageSize, sdId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        long totalItemCount = new List<UserDto>(_users).Count;
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<UserDto>(_users, 1, 50, totalItemCount));
                        return response;
                    }
                    else
                    {
                        string errors = ModelStateErrorExtensions.GetModelStateErrorsAsString(ModelState.Values);
                        return this.GenarateInternalServerError(errors);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
                }
            }
            else
            {
                return this.GenarateUnauthorizedServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        public PagedResult<UserDto> UserPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _userDomainService.GetUserCount(_dataRepositoryFactory);
            IEnumerable<UserDto> _users = _userDomainService.GetUserList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<UserDto>(_users, pageNo, pageSize, totalItemCount);
        }

        /// <summary>
        /// upload files api call
        /// </summary>
        /// <returns>result</returns>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/OwnersApi/UploadFiles")]
        public string UploadFiles()
        {
            int iUploadedCnt = 0;
            string filename = string.Empty;

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath(SystemResources.UserImageTempPath);

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    string prefix = Regex.Replace(DateTime.Now.ToString(), "[^a-zA-Z0-9% ._]", "-");
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)

                    filename = prefix + Path.GetFileName(hpf.FileName);

                    if (!File.Exists(sPath + filename))
                    {
                        // SAVE THE FILES IN THE FOLDER.
                        hpf.SaveAs(sPath + filename);
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                    else
                    {
                        File.Delete(sPath + filename);
                        hpf.SaveAs(sPath + filename);
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }
            }


            // RETURN A MESSAGE (OPTIONAL).
            if (iUploadedCnt > 0)
            {
                return filename;
            }
            else
            {
                return filename;
            }
        }
    }
}
