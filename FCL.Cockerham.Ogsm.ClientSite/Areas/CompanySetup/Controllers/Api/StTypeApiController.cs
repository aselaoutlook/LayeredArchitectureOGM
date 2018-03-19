using FCL.Cockerham.Ogsm.ClientSite.Core;
using FCL.Cockerham.Ogsm.ClientSite.Core.Util;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using FCL.Web.Framework.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.CompanySetup.Controllers.Api
{
    /// <summary>
    /// StType Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StTypeApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IStTypeService _stTypeDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [Authorize]
        [HttpGet]
        [Route("api/StTypeApi/GetAllStTypes")]
        public HttpResponseMessage GetAllStTypes()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<StTypeDto> _stTypes = _stTypeDomainService.GetAllStTypes(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _stTypes);
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

        /*
            **Comment On 11-13-2017 By Asela
            **Change Request By Heven: Change order of the filters in Dashboard
        */

        /*
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/StTypeApi/GetStTypesByBusinessUnitId")]
        public HttpResponseMessage GetStTypesByBusinessUnitId(long BusinessUnitId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<StTypeDto> _stTypes = _stTypeDomainService.GetStTypesByBusinessUnitId(BusinessUnitId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _stTypes);
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
        */

        [Authorize]
        public HttpResponseMessage Get(int pageNo = 1, int pageSize = 50)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    int skip = (pageNo - 1) * pageSize;
                    long totalItemCount = _stTypeDomainService.GetStTypeCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<StTypeDto> _stTypes = _stTypeDomainService.GetStTypeList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<StTypeDto>(_stTypes, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long StTypeId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    StTypeDto _stType = _stTypeDomainService.GetStTypeByStTypeId(StTypeId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _stType);
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

        public HttpResponseMessage Post(StTypeDto stType)
        {
            if (LoggedInUser != null)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        stType.OrganizationId = LoggedInUser.OrganizationId;
                        stType.CreatedBy = LoggedInUser.UserId;
                        stType.UpdatedBy = LoggedInUser.UserId;
                        stType.CreatedDate = DateTime.Now;
                        stType.UpdatedDate = _nullHandlerService.SetMinimumdate();
                        _stTypeDomainService.CreateStType(stType, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, StTypePagedList(1, 50));
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

        public HttpResponseMessage Put(StType stType)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        StTypeDto _stType = _stTypeDomainService.GetStTypeByStTypeId(stType.StTypeId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _stType.Name = stType.Name;
                        _stType.Description = stType.Description;
                        /*
                            **Comment On 11-13-2017 By Asela
                            **Change Request By Heven: Change order of the filters in Dashboard
                        */
        //_stType.BusinessUnitId = stType.BusinessUnitId;
                        _stType.IsActive = stType.IsActive;
                        _stType.UpdatedBy = LoggedInUser.UserId;
                        _stType.UpdatedDate = DateTime.Now;
                        _stTypeDomainService.UpdateStType(_stType, stType.StTypeId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, StTypePagedList(1, 50));
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

        public PagedResult<StTypeDto> StTypePagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _stTypeDomainService.GetStTypeCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<StTypeDto> _stTypes = _stTypeDomainService.GetStTypeList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<StTypeDto>(_stTypes, pageNo, pageSize, totalItemCount);
        }
    }
}
