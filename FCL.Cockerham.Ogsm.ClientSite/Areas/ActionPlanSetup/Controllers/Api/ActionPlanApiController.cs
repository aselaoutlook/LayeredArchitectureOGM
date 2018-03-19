using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web;
using System.Web.Http;
using System.Web.WebPages;
using FCL.Cockerham.Ogsm.ClientSite.Core.Util;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Cockerham.Ogsm.ClientSite.Core;
using System.Net.Http;
using System.Net;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.ActionPlanSetup.Controllers.Api
{
    /// <summary>
    /// ActionPlan Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActionPlanApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IActionPlanService _actionPlanDomainService { get; set; }

        [Import]
        IActionStatusService _actionStatusDomainService { get; set; }

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
                    long totalItemCount = _actionPlanDomainService.GetActionPlanCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<ActionPlanDto> _actionPlans = _actionPlanDomainService.GetActionPlanList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<ActionPlanDto>(_actionPlans, pageNo, pageSize, totalItemCount));
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

        public HttpResponseMessage Get(long ActionPlanId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    ActionPlanDto _actionPlan = _actionPlanDomainService.GetActionPlanByActionPlanId(ActionPlanId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _actionPlan);
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
        [System.Web.Http.Route("api/ActionPlanApi/GetAllActiveActionPlans")]
        public HttpResponseMessage GetAllActiveActionPlans()
        {
            if (LoggedInUser != null)
            {
                try
                {

                    IEnumerable<ActionPlanDto> _actionPlans = _actionPlanDomainService.GetAllActionPlans(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _actionPlans);
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
        [System.Web.Http.Route("api/ActionPlanApi/GetAllActionStatus")]
        public HttpResponseMessage GetAllActionStatus()
        {
            if (LoggedInUser != null)
            {
                try
                {

                    IEnumerable<ActionStatusDto> _actionStatus = _actionStatusDomainService.GetAllActionStatus(_dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _actionStatus);
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
        [System.Web.Http.Route("api/ActionPlanApi/GetActionPlansByStrategicDriverId")]
        public HttpResponseMessage GetActionPlansByStrategicDriverId(long StrategicDriverId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    //int skip = (pageNo - 1) * pageSize;
                    //IEnumerable<UserDto> _users = _userDomainService.GetAllActiveStrategicDriverEmployees(skip, pageSize, SdId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    //long totalItemCount = new List<UserDto>(_users).Count;
                    //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<UserDto>(_users, 1, 50, totalItemCount));
                    //return response;



                    IEnumerable<ActionPlanDto> _actionPlans = _actionPlanDomainService.GetActionPlansByStrategicDriverId(StrategicDriverId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _actionPlans);
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
        [System.Web.Http.Route("api/ActionPlanApi/GetAllActionPlansByStrategicDriverId")]
        public HttpResponseMessage GetAllActionPlansByStrategicDriverId(long StrategicDriverId, int pageNo = 1, int pageSize = 50)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    int skip = (pageNo - 1) * pageSize;
                    IEnumerable<ActionPlanDto> _actionPlans = _actionPlanDomainService.GetAllActionPlansByStrategicDriverId(skip, pageSize, StrategicDriverId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    long totalItemCount = new List<ActionPlanDto>(_actionPlans).Count;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<ActionPlanDto>(_actionPlans, 1, 50, totalItemCount));
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

        public HttpResponseMessage Post(ActionPlanDto actionPlan)
        {
            if (LoggedInUser != null)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        actionPlan.OrganizationId = LoggedInUser.OrganizationId;
                        actionPlan.CreatedBy = LoggedInUser.UserId;
                        actionPlan.UpdatedBy = LoggedInUser.UserId;
                        actionPlan.CreatedDate = DateTime.Now;
                        actionPlan.UpdatedDate = _nullHandlerService.SetMinimumdate();
                        actionPlan.CalendarEvents[0].OrganizationId = LoggedInUser.OrganizationId;
                        actionPlan.CalendarEvents[0].CreatedBy = LoggedInUser.UserId;
                        actionPlan.CalendarEvents[0].UpdatedBy = LoggedInUser.UserId;
                        actionPlan.CalendarEvents[0].CreatedDate = DateTime.Now;
                        actionPlan.CalendarEvents[0].UpdatedDate = _nullHandlerService.SetMinimumdate();
                        if (!actionPlan.ActionPlanComments[0].Comment.IsEmpty())
                        {
                            actionPlan.ActionPlanComments[0].CreatedBy = LoggedInUser.UserId;
                            actionPlan.ActionPlanComments[0].UpdatedBy = LoggedInUser.UserId;
                            actionPlan.ActionPlanComments[0].CreatedDate = DateTime.Now;
                            actionPlan.ActionPlanComments[0].UpdatedDate = _nullHandlerService.SetMinimumdate();
                        }
                        else
                        {
                            actionPlan.ActionPlanComments = null;
                        }
                        _actionPlanDomainService.CreateActionPlan(actionPlan, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ActionPlanPagedList(1, 50));
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

        public HttpResponseMessage Put(ActionPlan actionPlan)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        ActionPlanDto _actionPlan = _actionPlanDomainService.GetActionPlanByActionPlanIdAsTrackable(actionPlan.ActionPlanId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        _actionPlan.Name = actionPlan.Name;
                        _actionPlan.PillarId = actionPlan.PillarId;
                        _actionPlan.GoalId = actionPlan.GoalId;
                        _actionPlan.StrategicDriverId = actionPlan.StrategicDriverId;
                        _actionPlan.ActionPlanOwnerId = actionPlan.ActionPlanOwnerId;
                        _actionPlan.IsEvent = actionPlan.IsEvent;
                        _actionPlan.IsCalendarEvent = actionPlan.IsCalendarEvent;
                        _actionPlan.DueDate = actionPlan.DueDate;
                        _actionPlan.PlannedCost = actionPlan.PlannedCost;
                        _actionPlan.ActualCost = actionPlan.ActualCost;
                        _actionPlan.Impact = actionPlan.Impact;
                        _actionPlan.SequenceNumber = actionPlan.SequenceNumber;
                        _actionPlan.UpdatedBy = LoggedInUser.UserId;
                        _actionPlan.UpdatedDate = DateTime.Now;

                        //Update Calendar Event if Calendar Event exists
                        if (_actionPlan.IsCalendarEvent)
                        {
                            _actionPlan.CalendarEvents[0].Name = actionPlan.CalendarEvents[0].Name;
                            _actionPlan.CalendarEvents[0].Description = actionPlan.CalendarEvents[0].Description;
                            _actionPlan.CalendarEvents[0].Location = actionPlan.CalendarEvents[0].Location;
                            _actionPlan.CalendarEvents[0].IsActive = actionPlan.IsCalendarEvent;
                            _actionPlan.CalendarEvents[0].OrganizationId = LoggedInUser.OrganizationId;
                            _actionPlan.CalendarEvents[0].UpdatedBy = LoggedInUser.UserId;
                            _actionPlan.CalendarEvents[0].UpdatedDate = DateTime.Now;
                        }
                        else
                        {
                            _actionPlan.CalendarEvents[0].IsActive = _actionPlan.IsCalendarEvent;
                        }

                        //Update Action Plan Comments if Calendar Action Plan Comments exists
                        _actionPlan.ActionPlanComments[0].Comment = actionPlan.ActionPlanComments[0].Comment;
                        _actionPlan.ActionPlanComments[0].UpdatedBy = LoggedInUser.UserId;
                        _actionPlan.ActionPlanComments[0].UpdatedDate = DateTime.Now;

                        _actionPlanDomainService.UpdateActionPlan(_actionPlan, actionPlan.ActionPlanId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ActionPlanPagedList(1, 50));
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

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/ActionPlanApi/UpdateActionplanStatus")]
        public HttpResponseMessage Put(long actionPlanId, long actionStatusId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    ActionPlanDto _actionPlan = _actionPlanDomainService.GetActionPlanByActionPlanIdAsTrackable(actionPlanId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    _actionPlan.ActionStatusId = actionStatusId;
                    _actionPlan.UpdatedBy = LoggedInUser.UserId;
                    _actionPlan.UpdatedDate = DateTime.Now;

                    _actionPlanDomainService.UpdateActionPlan(_actionPlan, actionPlanId, _dataRepositoryFactory);

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

        public PagedResult<ActionPlanDto> ActionPlanPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _actionPlanDomainService.GetActionPlanCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<ActionPlanDto> _actionPlans = _actionPlanDomainService.GetActionPlanList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<ActionPlanDto>(_actionPlans, pageNo, pageSize, totalItemCount);
        }
    }
}
