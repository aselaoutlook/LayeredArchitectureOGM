using FCL.Cockerham.Ogsm.ClientSite.Core;
using FCL.Cockerham.Ogsm.ClientSite.Core.Filters;
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

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Strategy.Controllers.Api
{
    /// <summary>
    /// Strategic Driver Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StrategicDriverApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IStrategicDriverService _strategicDriverDomainService { get; set; }

        [Import]
        IStrategicDriverTargetService _strategicDriverTargetDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        public HttpResponseMessage Get(int pageNo = 1, int pageSize = 50)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    int skip = (pageNo - 1) * pageSize;
                    long totalItemCount = _strategicDriverDomainService.GetStrategicDriverCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<StrategicDriverDto> _strategicDrivers = _strategicDriverDomainService.GetStrategicDriverList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<StrategicDriverDto>(_strategicDrivers, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long StrategicDriverId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    StrategicDriverDto _strategicDriver = _strategicDriverDomainService.GetStrategicDriverByStrategicDriverId(StrategicDriverId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _strategicDriver);
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
        [Route("api/StrategicDriverApi/GetAllActiveStrategicDrivers")]
        public HttpResponseMessage GetAllActiveStrategicDrivers()
        {
            if (LoggedInUser != null)
            {
                try
                {                    
                    IEnumerable<StrategicDriverDto> _strategicDrivers = _strategicDriverDomainService.GetAllStrategicDrivers(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _strategicDrivers);
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
        [System.Web.Http.Route("api/StrategicDriverApi/GetStrategicDriverByGoalId")]
        public HttpResponseMessage GetStrategicDriverByGoalId(long goalId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    var session = HttpContext.Current.Session;
                    string _userType = (string)session["UserType"];

                    IEnumerable<StrategicDriverDto> _strategicDrivers = new List<StrategicDriverDto>();

                    if (_userType == Constants.SESSION_CLIENT_ADMIN)
                    {
                        //_strategicDrivers = _strategicDriverDomainService.GetStrategicDriverByGoalId(goalId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _strategicDrivers = _strategicDriverDomainService.GetAllStrategicDrivers(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    }
                    else if (this.HasRole(Constants.SESSION_EMPLOYEE))
                    {
                        if (_userType == Constants.SESSION_STRATEGY_OWNER)
                        {
                            //_strategicDrivers = _strategicDriverDomainService.GetStrategicDriverByGoalAndStrategyOwner(goalId, LoggedInUser.UserId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                            _strategicDrivers = _strategicDriverDomainService.GetStrategicDriverByStrategyOwnerId(LoggedInUser.UserId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        }
                    }

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _strategicDrivers);
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
        [System.Web.Http.Route("api/StrategicDriverApi/GetStrategicDriverByLoggedinUser")]
        public HttpResponseMessage GetStrategicDriverByLoggedinUser()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    var session = HttpContext.Current.Session;
                    string _userType = (string)session["UserType"];

                    IEnumerable<StrategicDriverDto> _strategicDrivers = new List<StrategicDriverDto>();

                    if (_userType == Constants.SESSION_CLIENT_ADMIN)
                    {
                        //_strategicDrivers = _strategicDriverDomainService.GetStrategicDriverByGoalId(goalId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _strategicDrivers = _strategicDriverDomainService.GetAllStrategicDrivers(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    }
                    else if (this.HasRole(Constants.SESSION_EMPLOYEE))
                    {
                        if (_userType == Constants.SESSION_STRATEGY_OWNER)
                        {
                            //_strategicDrivers = _strategicDriverDomainService.GetStrategicDriverByGoalAndStrategyOwner(goalId, LoggedInUser.UserId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                            _strategicDrivers = _strategicDriverDomainService.GetStrategicDriverByStrategyOwnerId(LoggedInUser.UserId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        }
                    }

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _strategicDrivers);
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

        public HttpResponseMessage Post(StrategicDriverDto strategicDriver)
        {
            if (LoggedInUser != null)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        strategicDriver.OrganizationId = LoggedInUser.OrganizationId;
                        strategicDriver.CreatedBy = LoggedInUser.UserId;
                        strategicDriver.UpdatedBy = LoggedInUser.UserId;
                        strategicDriver.CreatedDate = DateTime.Now;
                        strategicDriver.UpdatedDate = _nullHandlerService.SetMinimumdate();
                        StrategicDriverDto _createdStrategicDriver = _strategicDriverDomainService.CreateStrategicDriver(strategicDriver, _dataRepositoryFactory);

                        if (_createdStrategicDriver != null)
                        {
                            if(!_strategicDriverDomainService.CreateStrategicDriverTargetsForStrategy(_createdStrategicDriver, LoggedInUser, _strategicDriverTargetDomainService, _dataRepositoryFactory))
                            {
                                return this.GenarateInternalServerError(Resources.SystemMessages.ErrorCreatingGoalTargets);
                            }
                        }

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, StrategicDriverPagedList(1, 50));
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

        public HttpResponseMessage Put(StrategicDriverDto strategicDriver)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        StrategicDriverDto _strategicDriver = _strategicDriverDomainService.GetStrategicDriverByStrategicDriverId(strategicDriver.StrategicDriverId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _strategicDriver.Name = strategicDriver.Name;
                        _strategicDriver.GoalCategoryId = strategicDriver.GoalCategoryId;
                        //_strategicDriver.StTypeId = strategicDriver.StTypeId;
                        _strategicDriver.StartDate = strategicDriver.StartDate;
                        _strategicDriver.EndDate = strategicDriver.EndDate;
                        _strategicDriver.GoalId = strategicDriver.GoalId;
                        _strategicDriver.Metric = strategicDriver.Metric;
                        _strategicDriver.MetricTarget = strategicDriver.MetricTarget;
                        _strategicDriver.SequenceNumber = strategicDriver.SequenceNumber;
                        _strategicDriver.IsMetricDefault = strategicDriver.IsMetricDefault;
                        _strategicDriver.IsIndexed = strategicDriver.IsIndexed;
                        _strategicDriver.IsActive = strategicDriver.IsActive;
                        _strategicDriver.WeightActionPlan = strategicDriver.WeightActionPlan;
                        _strategicDriver.WeightMetric = strategicDriver.WeightMetric;
                        _strategicDriver.OwnerId = strategicDriver.OwnerId;
                        _strategicDriver.UpdatedBy = LoggedInUser.UserId;
                        _strategicDriver.UpdatedDate = DateTime.Now;
                        StrategicDriverDto _updatedStrategicDriver = _strategicDriverDomainService.UpdateStrategicDriver(_strategicDriver, strategicDriver.StrategicDriverId, _dataRepositoryFactory);

                        if (_strategicDriver.StrategicDriverTargets.Count <= 0)
                        {
                            if (!_strategicDriverDomainService.CreateStrategicDriverTargetsForStrategy(_updatedStrategicDriver, LoggedInUser, _strategicDriverTargetDomainService, _dataRepositoryFactory))
                            {
                                return this.GenarateInternalServerError(Resources.SystemMessages.ErrorCreatingGoalTargets);
                            }
                        }

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, StrategicDriverPagedList(1, 50));
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

        [HttpPut]
        [Route("api/StrategicDriverApi/UpdateStrategicDriverTargets")]
        public HttpResponseMessage UpdateStrategicDriverTargets(StrategicDriverDto strategicDriver)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    StrategicDriverDto _existingStrategicDriver = _strategicDriverDomainService.GetStrategicDriverByStrategicDriverId(strategicDriver.StrategicDriverId, LoggedInUser.OrganizationId, _dataRepositoryFactory);

                    _existingStrategicDriver.MetricTarget = strategicDriver.MetricTarget;
                    _strategicDriverDomainService.UpdateStrategicDriver(_existingStrategicDriver, strategicDriver.StrategicDriverId, _dataRepositoryFactory);

                    foreach (StrategicDriverTarget target in strategicDriver.StrategicDriverTargets)
                    {
                        StrategicDriverTargetDto existingTarget = _strategicDriverTargetDomainService.GetStrategicDriverTargetByStrategicDriverTargetId(target.StrategicDriverTargetId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        existingTarget.QuaterValue = target.QuaterValue;

                        _strategicDriverTargetDomainService.UpdateStrategicDriverTarget(existingTarget, existingTarget.StrategicDriverTargetId, _dataRepositoryFactory);
                    }

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
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

        public PagedResult<StrategicDriverDto> StrategicDriverPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _strategicDriverDomainService.GetStrategicDriverCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<StrategicDriverDto> _strategicDrivers = _strategicDriverDomainService.GetStrategicDriverList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<StrategicDriverDto>(_strategicDrivers, pageNo, pageSize, totalItemCount);
        }
    }
}