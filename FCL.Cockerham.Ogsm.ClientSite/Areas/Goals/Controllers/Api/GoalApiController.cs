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

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Goals.Controllers.Api
{
    /// <summary>
    /// Goal Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GoalApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IGoalService _goalDomainService { get; set; }

        [Import]
        IGoalTargetService _goalDomainTargetService { get; set; }

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

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, GoalPagedList(1, 50));
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
        [Route("api/GoalApi/GetGoalByPillarId")]
        public HttpResponseMessage GetGoalByPillarId(long PillarId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<GoalDto> _goals = _goalDomainService.GetGoalByPillarId(PillarId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _goals);
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

        public HttpResponseMessage Get(long GoalId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    GoalDto _goal = _goalDomainService.GetGoalByGoalId(GoalId, LoggedInUser.OrganizationId, _dataRepositoryFactory);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _goal);
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

        public HttpResponseMessage Post(GoalDto goal)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        int yearCount = goal.EndDate.Year - goal.StartDate.Year;

                        goal.GoalYears = yearCount;
                        goal.OrganizationId = LoggedInUser.OrganizationId;
                        goal.CreatedBy = LoggedInUser.UserId;
                        goal.UpdatedBy = LoggedInUser.UserId;
                        goal.CreatedDate = DateTime.Now;
                        goal.UpdatedDate = _nullHandlerService.SetMinimumdate();

                        GoalDto _createdGoal = _goalDomainService.CreateGoal(goal, _dataRepositoryFactory);

                        if (_createdGoal != null)
                        {
                            try
                            {
                                for (int i = 0; i <= _createdGoal.GoalYears; i++)
                                {
                                    int year = _createdGoal.StartDate.Year;
                                    GoalTargetDto target = new GoalTargetDto();
                                    DateTime targetStartDate = new DateTime(year + i, 1, 1);
                                    DateTime targetEndDate = new DateTime(year + i, 12, 31);
                                    target.YearName = "Year " + (i + 1).ToString();
                                    target.EndDate = targetEndDate;
                                    target.StartDate = targetStartDate;
                                    target.IsActive = true;

                                    target.GoalId = _createdGoal.GoalId;
                                    target.YearValue = -1;
                                    target.Results = -1;
                                    target.OrganizationId = LoggedInUser.OrganizationId;
                                    target.CreatedBy = LoggedInUser.UserId;
                                    target.UpdatedBy = LoggedInUser.UserId;
                                    target.CreatedDate = DateTime.Now;
                                    target.UpdatedDate = _nullHandlerService.SetMinimumdate();
                                    _goalDomainTargetService.CreateGoalTarget(target, _dataRepositoryFactory);
                                }
                            }
                            catch (Exception)
                            {
                                return this.GenarateInternalServerError(Resources.SystemMessages.ErrorCreatingGoalTargets);
                            }

                            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, GoalPagedList(1, 50));
                            return response;
                        }
                        else
                        {
                            return this.GenarateInternalServerError(Resources.SystemMessages.ErrorCreatingGoalTargets);
                        }

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
        
        public HttpResponseMessage Put(Goal goal)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        int yearCount = goal.EndDate.Year - goal.StartDate.Year;
                        GoalDto _goal = _goalDomainService.GetGoalByGoalId(goal.GoalId, LoggedInUser.OrganizationId, _dataRepositoryFactory);

                        _goal.Name = goal.Name;
                        _goal.PillarId = goal.PillarId;
                        _goal.StartDate = goal.StartDate;
                        _goal.EndDate = goal.EndDate;
                        _goal.SequenceNumber = goal.SequenceNumber;
                        _goal.PrimaryOwnerId = goal.PrimaryOwnerId;
                        _goal.SecondryOwnerId = goal.SecondryOwnerId;
                        _goal.RationaleNotes = goal.RationaleNotes;
                        _goal.Target = goal.Target;
                        _goal.GoalYears = yearCount;
                        _goal.IsActive = goal.IsActive;
                        _goal.UpdatedBy = LoggedInUser.UserId;
                        _goal.UpdatedDate = DateTime.Now;
                        _goalDomainService.UpdateGoal(_goal, goal.GoalId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, GoalPagedList(1, 50));
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
        [Route("api/GoalApi/UpdateGoalTargets")]
        public HttpResponseMessage UpdateGoalTargets(GoalDto goal)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    GoalDto _existingGoal = _goalDomainService.GetGoalByGoalId(goal.GoalId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    _existingGoal.Target = goal.Target;
                    _existingGoal.TargetDesc = goal.TargetDesc;
                    _goalDomainService.UpdateGoal(_existingGoal, goal.GoalId, _dataRepositoryFactory);

                    foreach (GoalTargetPlainDto target in goal.GoalTargets)
                    {
                        GoalTargetDto existingTarget = _goalDomainTargetService.GetGoalTargetByGoalTargetId(target.GoalTargetId, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                        existingTarget.YearValue = target.YearValue;
                        existingTarget.Results = target.Results;

                        _goalDomainTargetService.UpdateGoalTarget(existingTarget, existingTarget.GoalTargetId, _dataRepositoryFactory);
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

        public PagedResult<GoalDto> GoalPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _goalDomainService.GetGoalCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<GoalDto> _goals = _goalDomainService.GetGoalList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<GoalDto>(_goals, pageNo, pageSize, totalItemCount);
        }

        //public bool CreateGoalTargets(Goal goal)
        //{
        //    try
        //    {
        //        for (int i = 0; i < goal.GoalYears; i++)
        //        {
        //            int year = goal.StartDate.Year;
        //            GoalTarget target = new GoalTarget();
        //            DateTime targetStartDate = new DateTime(year + i, 1, 1);
        //            DateTime targetEndDate = new DateTime(year + i, 12, 31);
        //            target.YearName = "Year " + (i + 1).ToString();
        //            target.EndDate = targetEndDate;
        //            target.StartDate = targetStartDate;

        //            if (((goal.StartDate <= target.EndDate) && (goal.StartDate >= targetStartDate)) || ((goal.EndDate <= target.EndDate) && (goal.EndDate >= targetStartDate)))
        //            {
        //                target.IsActive = true;
        //            }
        //            else
        //            {
        //                target.IsActive = false;
        //            }

        //            target.GoalId = goal.GoalId;
        //            target.YearValue = -1;
        //            target.Results = -1;
        //            target.OrganizationId = LoggedInUser.OrganizationId;
        //            target.CreatedBy = LoggedInUser.UserId;
        //            target.UpdatedBy = LoggedInUser.UserId;
        //            target.CreatedDate = DateTime.Now;
        //            target.UpdatedDate = _nullHandlerService.SetMinimumdate();
        //            _goalTargetService.CreateGoalTarget(target, _dataRepositoryFactory);
        //        }

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
