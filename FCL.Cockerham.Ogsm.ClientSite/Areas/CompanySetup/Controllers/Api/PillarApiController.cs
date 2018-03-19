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
    /// Pillar Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PillarApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IPillarService _pillarDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/PillarApi/GetAllPillarsByOrganization")]
        public HttpResponseMessage GetAllPillarsByOrganization()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<PillarDto> _pillars = _pillarDomainService.GetAllPillars(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _pillars);
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

        [HttpGet]
        [Route("api/PillarApi/GetPillarsByStTypeId")]
        public HttpResponseMessage GetPillarsByStTypeId(long StTypeId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<PillarDto> _pillarStTypes = _pillarDomainService.GetPillarsByStTypeId(StTypeId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _pillarStTypes);
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
                    long totalItemCount = _pillarDomainService.GetPillarCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<PillarDto> _pillars = _pillarDomainService.GetPillarList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<PillarDto>(_pillars, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long PillarId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    PillarDto _pillar = _pillarDomainService.GetPillarByPillarId(PillarId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _pillar);
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

        public HttpResponseMessage Post(PillarDto pillar)
        {
            if (LoggedInUser != null)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        pillar.OrganizationId = LoggedInUser.OrganizationId;
                        pillar.CreatedBy = LoggedInUser.UserId;
                        pillar.UpdatedBy = LoggedInUser.UserId;
                        pillar.CreatedDate = DateTime.Now;
                        pillar.UpdatedDate = _nullHandlerService.SetMinimumdate();
                        _pillarDomainService.CreatePillar(pillar, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, PillarPagedList(1, 50));
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

        public HttpResponseMessage Put(PillarDto pillar)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        PillarDto _pillar = _pillarDomainService.GetPillarByPillarId(pillar.PillarId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _pillar.Name = pillar.Name;
                        _pillar.Description = pillar.Description;
                        _pillar.StTypeId = pillar.StTypeId;
                        _pillar.SequenceNumber = pillar.SequenceNumber;
                        _pillar.IsActive = pillar.IsActive;
                        _pillar.UpdatedBy = LoggedInUser.UserId;
                        _pillar.UpdatedDate = DateTime.Now;
                        _pillarDomainService.UpdatePillar(_pillar, pillar.PillarId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, PillarPagedList(1, 50));
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

        public PagedResult<PillarDto> PillarPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _pillarDomainService.GetPillarCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<PillarDto> _pillars = _pillarDomainService.GetPillarList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<PillarDto>(_pillars, pageNo, pageSize, totalItemCount);
        }
    }
}
