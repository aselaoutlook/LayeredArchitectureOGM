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
    /// Country Api Controller
    /// </summary>
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CountryApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        ICountryService _countryDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [HttpGet]
        [Route("api/CountryApi/GetCountriesByGlobalRegionId")]
        public HttpResponseMessage GetCountriesByGlobalRegionId(long GrId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<CountryDto> _countryRegions = _countryDomainService.GetCountryiesByGlobalRegionId(GrId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _countryRegions);
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
                    long totalItemCount = _countryDomainService.GetCountryCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<CountryDto> _countrys = _countryDomainService.GetCountryList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<CountryDto>(_countrys, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long CountryId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    CountryDto _country = _countryDomainService.GetCountryByCountryId(CountryId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _country);
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

        public HttpResponseMessage Post(CountryDto country)
        {
            if (LoggedInUser != null)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        country.OrganizationId = LoggedInUser.OrganizationId;
                        _countryDomainService.CreateCountry(country, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, CountryPagedList(1, 50));
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

        public HttpResponseMessage Put(CountryDto country)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        CountryDto _country = _countryDomainService.GetCountryByCountryId(country.CountryId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _country.Name = country.Name;
                        _country.GlobalRegionId = country.GlobalRegionId;
                        _countryDomainService.UpdateCountry(_country, country.CountryId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, CountryPagedList(1, 50));
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

        public PagedResult<CountryDto> CountryPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _countryDomainService.GetCountryCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<CountryDto> _countrys = _countryDomainService.GetCountryList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<CountryDto>(_countrys, pageNo, pageSize, totalItemCount);
        }
    }
}
