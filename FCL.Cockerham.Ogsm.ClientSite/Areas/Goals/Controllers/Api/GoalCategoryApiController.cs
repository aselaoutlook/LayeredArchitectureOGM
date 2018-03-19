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
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Areas.Goals.Controllers.Api
{
    /// <summary>
    /// Goal Category Api Controller
    /// </summary>
    [System.Web.Mvc.Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GoalCategoryApiController : ApiControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IUserService _userDomainService { get; set; }

        [Import]
        IGoalCategoryService _goalCategoryDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        INullHandler _nullHandlerService { get; set; }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GoalCategoryApi/GetAllGoalCategoriesByOrganization")]
        public HttpResponseMessage GetAllGoalCategoriesByOrganization()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<GoalCategoryDto> _goalCategories = _goalCategoryDomainService.GetAllGoalCategoriesByOrganization(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _goalCategories);
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
        [System.Web.Http.Route("api/GoalCategoryApi/GetGoalCategoriesByDepartmentId")]
        public HttpResponseMessage GetGoalCategoriesByDepartmentId(long DepartmentId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<GoalCategoryDto> _goalCategoryies = _goalCategoryDomainService.GetGoalCategoryByDepartment(DepartmentId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _goalCategoryies);
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
                    long totalItemCount = _goalCategoryDomainService.GetGoalCategoryCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    IEnumerable<GoalCategoryDto> _goalCategorys = _goalCategoryDomainService.GetGoalCategoryList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new PagedResult<GoalCategoryDto>(_goalCategorys, pageNo, pageSize, totalItemCount));
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
        [System.Web.Http.Route("Goal/api/GoalCategoryApi/GetAllGoalCategories")]
        public HttpResponseMessage GetAllGoalCategories()
        {
            if (LoggedInUser != null)
            {
                try
                {
                    IEnumerable<GoalCategoryDto> _goalCategories = _goalCategoryDomainService.GetAllGoalCategorys(LoggedInUser.OrganizationId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _goalCategories);
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

        public HttpResponseMessage Get(long GoalCategoryId)
        {
            if (LoggedInUser != null)
            {
                try
                {
                    GoalCategoryDto _goalCategory = _goalCategoryDomainService.GetGoalCategoryByGoalCategoryId(GoalCategoryId, _dataRepositoryFactory);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _goalCategory);
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

        public HttpResponseMessage Post(GoalCategoryDto goalCategory)
        {
            if (LoggedInUser != null)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        goalCategory.OrganizationId = LoggedInUser.OrganizationId;
                        _goalCategoryDomainService.CreateGoalCategory(goalCategory, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, GoalCategoryPagedList(1, 50));
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

        public HttpResponseMessage Put(GoalCategoryDto goalCategory)
        {
            if (LoggedInUser != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        GoalCategoryDto _goalCategory = _goalCategoryDomainService.GetGoalCategoryByGoalCategoryId(goalCategory.GoalCategoryId, _dataRepositoryFactory);
                        _goalCategory.StTypeId = goalCategory.StTypeId;
                        _goalCategory.Name = goalCategory.Name;
                        _goalCategoryDomainService.UpdateGoalCategory(_goalCategory, goalCategory.GoalCategoryId, _dataRepositoryFactory);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, GoalCategoryPagedList(1, 50));
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

        public PagedResult<GoalCategoryDto> GoalCategoryPagedList(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;
            long totalItemCount = _goalCategoryDomainService.GetGoalCategoryCount(LoggedInUser.OrganizationId, _dataRepositoryFactory);
            IEnumerable<GoalCategoryDto> _goalCategorys = _goalCategoryDomainService.GetGoalCategoryList(skip, pageSize, LoggedInUser.OrganizationId, _dataRepositoryFactory);
            return new PagedResult<GoalCategoryDto>(_goalCategorys, pageNo, pageSize, totalItemCount);
        }
    }
}
