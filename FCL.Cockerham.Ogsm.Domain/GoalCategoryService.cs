using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using AutoMapper;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IGoalCategoryService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GoalCategoryService:IGoalCategoryService
    {
        public GoalCategoryDto CreateGoalCategory(GoalCategoryDto _goalCategory, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            GoalCategoryDto _createdGoalCategory = Mapper.Map<GoalCategoryDto>(GoalCategoryService.Add(Mapper.Map<GoalCategory>(_goalCategory)));

            return _createdGoalCategory;
        }

        public GoalCategoryDto UpdateGoalCategory(GoalCategoryDto _goalCategory, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            GoalCategoryDto _updatedGoalCategory = Mapper.Map<GoalCategoryDto>(GoalCategoryService.Update(Mapper.Map<GoalCategory>(_goalCategory)));

            return _updatedGoalCategory;
        }

        public GoalCategoryDto UpdateGoalCategory(GoalCategoryDto _goalCategory, long _goalCategoryId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            GoalCategoryDto _updatedGoalCategory = Mapper.Map<GoalCategoryDto>(GoalCategoryService.Update(Mapper.Map<GoalCategory>(_goalCategory), _goalCategoryId));

            return _updatedGoalCategory;
        }

        public GoalCategoryDto GetGoalCategoryByGoalCategoryId(long _goalCategoryId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            GoalCategoryDto _goalCategory = Mapper.Map<GoalCategoryDto>(GoalCategoryService.GetSingle(s => s.GoalCategoryId.Equals(_goalCategoryId), "Department"));
            return _goalCategory;
        }

        public ICollection<GoalCategoryDto> GetAllGoalCategorys(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            ICollection<GoalCategoryDto> _allGoalCategorys = Mapper.Map<ICollection<GoalCategoryDto>>(GoalCategoryService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allGoalCategorys;
        }

        public IEnumerable<GoalCategoryDto> GetGoalCategoryList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            IEnumerable<GoalCategoryDto> _allGoalCategorys = Mapper.Map<IEnumerable<GoalCategoryDto>>(GoalCategoryService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), null));

            return _allGoalCategorys;
        }

        public long GetGoalCategoryCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            return GoalCategoryService.Count(i => i.OrganizationId.Equals(_organizationId)); 
        }

        public ICollection<GoalCategoryDto> GetAllGoalCategoriesByOrganization(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            ICollection<GoalCategoryDto> _allGoalCategories = Mapper.Map<ICollection<GoalCategoryDto>>(GoalCategoryService.GetListWithNavigation(i => i.OrganizationId.Equals(_organizationId)));

            return _allGoalCategories;
        }

        public IEnumerable<GoalCategoryDto> GetGoalCategoryByDepartment(long _stTypeId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalCategory> GoalCategoryService = _dataRepositoryFactory.GetRepository<GoalCategory>();
            IEnumerable<GoalCategoryDto> _goalCategories = Mapper.Map<IEnumerable<GoalCategoryDto>>(GoalCategoryService.GetList(c => c.StTypeId == _stTypeId, null, "Department"));

            return _goalCategories;
        }
    }
}