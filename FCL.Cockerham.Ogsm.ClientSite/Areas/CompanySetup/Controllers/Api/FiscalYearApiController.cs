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
    /// Fiscal Year Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FiscalYearApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IFiscalYearService _fiscalYearDomainService { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Authorize]
        [HttpGet]
        [Route("api/FiscalYearApi/GetAllFiscalYears")]
        public HttpResponseMessage GetAllFiscalYears()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<FiscalYearDto> _fiscalYears = _fiscalYearDomainService.GetAllFiscalYears(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _fiscalYears);
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
                    long totalItemCount = _fiscalYearDomainService.GetFiscalYearCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<FiscalYearDto> _fiscalYears = _fiscalYearDomainService.GetFiscalYearList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<FiscalYearDto>(_fiscalYears, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long FiscalYearId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    FiscalYearDto _fiscalYear = _fiscalYearDomainService.GetFiscalYearByFiscalYearId(FiscalYearId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _fiscalYear);
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

        public HttpResponseMessage Post(FiscalYearDto fiscalYear)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        fiscalYear.OrganizationId = LoggedInUser.OrganizationId;
                        fiscalYear.CreatedBy = LoggedInUser.UserId;
                        fiscalYear.UpdatedBy = LoggedInUser.UserId;
                        fiscalYear.CreatedDate = DateTime.Now;
                        fiscalYear.UpdatedDate = _nullHandlerService.SetMinimumdate();
                        _fiscalYearDomainService.CreateFiscalYear(fiscalYear, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, FiscalYearPagedList(1, 50));
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

        public HttpResponseMessage Put(FiscalYear fiscalYear)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        FiscalYearDto _fiscalYear = _fiscalYearDomainService.GetFiscalYearByFiscalYearId(fiscalYear.FiscalYearId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _fiscalYear.StartYear = fiscalYear.StartYear;
                        _fiscalYear.EndYear = fiscalYear.EndYear;
                        _fiscalYear.EvaluationLength = fiscalYear.EvaluationLength;
                        _fiscalYear.Description = fiscalYear.Description;
                        _fiscalYear.IsActive = fiscalYear.IsActive;
                        _fiscalYear.UpdatedBy = LoggedInUser.UserId;
                        _fiscalYear.UpdatedDate = DateTime.Now;
                        _fiscalYearDomainService.UpdateFiscalYear(_fiscalYear, fiscalYear.FiscalYearId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, FiscalYearPagedList(1, 50));
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

        public PagedResult<FiscalYearDto> FiscalYearPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _fiscalYearDomainService.GetFiscalYearCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<FiscalYearDto> _fiscalYears = _fiscalYearDomainService.GetFiscalYearList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<FiscalYearDto>(_fiscalYears, pageNo, pageSize, totalItemCount);
        }
    }
}
