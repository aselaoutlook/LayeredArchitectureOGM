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
using System.Web.Http;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.CompanySetup.Controllers.Api
{
    /// <summary>
    /// Global Region Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GlobalRegionApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IGlobalRegionService _globalRegionDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [HttpGet]
        [Route("api/GlobalRegionApi/GetAllRegions")]
        public HttpResponseMessage GetAllRegions()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<GlobalRegionDto> _globalRegions = _globalRegionDomainService.GetAllGlobalRegions(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _globalRegions);
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
                    long totalItemCount = _globalRegionDomainService.GetGlobalRegionCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<GlobalRegionDto> _globalRegions = _globalRegionDomainService.GetGlobalRegionList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<GlobalRegionDto>(_globalRegions, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long GlobalRegionId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    GlobalRegionDto _globalRegion = _globalRegionDomainService.GetGlobalRegionByGlobalRegionId(GlobalRegionId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _globalRegion);
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

        public HttpResponseMessage Post(GlobalRegionDto globalRegion)
        {
            if (LoggedInUser != null)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        globalRegion.OrganizationId = LoggedInUser.OrganizationId;
                        _globalRegionDomainService.CreateGlobalRegion(globalRegion, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, GlobalRegionPagedList(1, 50));
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

        public HttpResponseMessage Put(GlobalRegionDto globalRegion)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        GlobalRegionDto _globalRegion = _globalRegionDomainService.GetGlobalRegionByGlobalRegionId(globalRegion.GlobalRegionId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _globalRegion.Name = globalRegion.Name;
                        _globalRegionDomainService.UpdateGlobalRegion(_globalRegion, globalRegion.GlobalRegionId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, GlobalRegionPagedList(1, 50));
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

        public PagedResult<GlobalRegionDto> GlobalRegionPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _globalRegionDomainService.GetGlobalRegionCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<GlobalRegionDto> _globalRegions = _globalRegionDomainService.GetGlobalRegionList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<GlobalRegionDto>(_globalRegions, pageNo, pageSize, totalItemCount);
        }
    }
}
