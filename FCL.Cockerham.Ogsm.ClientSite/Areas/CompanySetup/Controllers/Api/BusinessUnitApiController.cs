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
    /// Business Unit Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BusinessUnitApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IBusinessUnitService _businessUnitDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [Authorize]
        [HttpGet]
        [Route("api/BusinessUnitApi/GetAllBusinessUnits")]
        public HttpResponseMessage GetAllBusinessUnits()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<BusinessUnitDto> _businessUnits = _businessUnitDomainService.GetAllBusinessUnits(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _businessUnits);
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
        [System.Web.Http.Route("api/BusinessUnitApi/GetBusinessUnitsByStTypeId")]
        public HttpResponseMessage GetBusinessUnitsByStTypeId(long StTypeId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<BusinessUnitDto> _businessUnits = _businessUnitDomainService.GetBusinessUnitsByStTypeId(StTypeId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _businessUnits);
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

        [Authorize]
        public HttpResponseMessage Get(int pageNo = 1, int pageSize = 50)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    int skip = (pageNo - 1) * pageSize;
                    long totalItemCount = _businessUnitDomainService.GetBusinessUnitCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<BusinessUnitDto> _businessUnits = _businessUnitDomainService.GetBusinessUnitList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<BusinessUnitDto>(_businessUnits, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long BusinessUnitId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    BusinessUnitDto _businessUnit = _businessUnitDomainService.GetBusinessUnitByBusinessUnitId(BusinessUnitId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _businessUnit);
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

        public HttpResponseMessage Post(BusinessUnitDto businessUnit)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        businessUnit.OrganizationId = LoggedInUser.OrganizationId;
                        businessUnit.CreatedBy = LoggedInUser.UserId;
                        businessUnit.UpdatedBy = LoggedInUser.UserId;
                        businessUnit.CreatedDate = DateTime.Now;
                        businessUnit.UpdatedDate = _nullHandlerService.SetMinimumdate();
                        _businessUnitDomainService.CreateBusinessUnit(businessUnit, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, BusinessUnitPagedList(1, 50));
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

        public HttpResponseMessage Put(BusinessUnitDto businessUnit)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        BusinessUnitDto _businessUnit = _businessUnitDomainService.GetBusinessUnitByBusinessUnitId(businessUnit.BusinessUnitId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _businessUnit.Name = businessUnit.Name;
                        _businessUnit.Description = businessUnit.Description;
                        _businessUnit.Location = businessUnit.Location;
                        _businessUnit.StTypeId = businessUnit.StTypeId;
                        _businessUnit.IsActive = businessUnit.IsActive;
                        _businessUnit.UpdatedBy = LoggedInUser.UserId;
                        _businessUnit.UpdatedDate = DateTime.Now;
                        _businessUnitDomainService.UpdateBusinessUnit(_businessUnit, businessUnit.BusinessUnitId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, BusinessUnitPagedList(1, 50));
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

        public PagedResult<BusinessUnitDto> BusinessUnitPagedList(int pageNo, int pageSize)
        {
            try
            {
                int skip = (pageNo - 1) * pageSize;
                long totalItemCount = _businessUnitDomainService.GetBusinessUnitCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                IEnumerable<BusinessUnitDto> _businessUnits = _businessUnitDomainService.GetBusinessUnitList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                return new PagedResult<BusinessUnitDto>(_businessUnits, pageNo, pageSize, totalItemCount);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}
