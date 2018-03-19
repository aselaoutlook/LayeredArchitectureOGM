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
    /// Csf Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CsfApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        ICsfService _csfDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [HttpGet]
        [Route("api/CsfApi/GetCsfByStTypeId")]
        public HttpResponseMessage GetCsfByStTypeId(long GrId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<CsfDto> _csfStTypes = _csfDomainService.GetCsfByStTypeId(GrId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _csfStTypes);
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
                    long totalItemCount = _csfDomainService.GetCsfCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<CsfDto> _csfs = _csfDomainService.GetCsfList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<CsfDto>(_csfs, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long CsfId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    CsfDto _csf = _csfDomainService.GetCsfByCsfId(CsfId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _csf);
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

        public HttpResponseMessage Post(CsfDto csf)
        {
            if (LoggedInUser != null)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        csf.OrganizationId = LoggedInUser.OrganizationId;
                        csf.CreatedBy = LoggedInUser.UserId;
                        csf.UpdatedBy = LoggedInUser.UserId;
                        csf.CreatedDate = DateTime.Now;
                        csf.UpdatedDate = _nullHandlerService.SetMinimumdate();
                        _csfDomainService.CreateCsf(csf, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, CsfPagedList(1, 50));
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

        public HttpResponseMessage Put(Csf csf)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        CsfDto _csf = _csfDomainService.GetCsfByCsfId(csf.CsfId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _csf.Name = csf.Name;
                        _csf.Description = csf.Description;
                        _csf.StTypeId = csf.StTypeId;
                        _csf.SequenceNumber = csf.SequenceNumber;
                        _csf.IsActive = csf.IsActive;
                        _csf.UpdatedBy = LoggedInUser.UserId;
                        _csf.UpdatedDate = DateTime.Now;
                        _csfDomainService.UpdateCsf(_csf, csf.CsfId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, CsfPagedList(1, 50));
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

        public PagedResult<CsfDto> CsfPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _csfDomainService.GetCsfCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<CsfDto> _csfs = _csfDomainService.GetCsfList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<CsfDto>(_csfs, pageNo, pageSize, totalItemCount);
        }
    }
}
