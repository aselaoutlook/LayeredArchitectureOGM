using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IGoalCategoryService
    {
        GoalCategoryDto CreateGoalCategory(GoalCategoryDto _goalCategory, IUnitOfWork _dataRepositoryFactory);
        GoalCategoryDto UpdateGoalCategory(GoalCategoryDto _goalCategory, IUnitOfWork _dataRepositoryFactory);
        GoalCategoryDto UpdateGoalCategory(GoalCategoryDto _goalCategory, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        GoalCategoryDto GetGoalCategoryByGoalCategoryId(long _goalCategoryId, IUnitOfWork _dataRepositoryFactory);
        ICollection<GoalCategoryDto> GetAllGoalCategorys(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<GoalCategoryDto> GetGoalCategoryList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetGoalCategoryCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<GoalCategoryDto> GetAllGoalCategoriesByOrganization(long orgId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<GoalCategoryDto> GetGoalCategoryByDepartment(long _departmentId, IUnitOfWork _dataRepositoryFactory);
    }
}