using System;
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
    [Export(typeof(IGoalService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GoalService : IGoalService
    {
        public GoalDto CreateGoal(GoalDto _goalCategory, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Goal> GoalService = _dataRepositoryFactory.GetRepository<Goal>();
            GoalDto _createdGoal = Mapper.Map<GoalDto>(GoalService.Add(Mapper.Map<Goal>(_goalCategory)));

            return _createdGoal;
        }

        public GoalDto UpdateGoal(GoalDto _goalCategory, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Goal> GoalService = _dataRepositoryFactory.GetRepository<Goal>();
            GoalDto _updatedGoal = Mapper.Map<GoalDto>(GoalService.Update(Mapper.Map<Goal>(_goalCategory)));

            return _updatedGoal;
        }

        public GoalDto UpdateGoal(GoalDto _goalCategory, long _goalCategoryId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Goal> GoalService = _dataRepositoryFactory.GetRepository<Goal>();
            GoalDto _updatedGoal = Mapper.Map<GoalDto>(GoalService.Update(Mapper.Map<Goal>(_goalCategory), _goalCategoryId));

            return _updatedGoal;
        }

        public GoalDto GetGoalByGoalId(long _goalId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Goal> GoalService = _dataRepositoryFactory.GetRepository<Goal>();
            GoalDto _goalCategory = Mapper.Map<GoalDto>(GoalService.GetSingle(g => g.GoalId.Equals(_goalId) && g.OrganizationId.Equals(_organizationId), "Pillar, PrimaryOwner, SecondryOwner, GoalTargets"));

            return _goalCategory;
        }

        public ICollection<GoalDto> GetAllGoals(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Goal> GoalService = _dataRepositoryFactory.GetRepository<Goal>();
            ICollection<GoalDto> _allGoals = Mapper.Map<ICollection<GoalDto>>(GoalService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allGoals;
        }

        public IEnumerable<GoalDto> GetGoalList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Goal> GoalService = _dataRepositoryFactory.GetRepository<Goal>();
            IEnumerable<GoalDto> _allGoals = Mapper.Map<IEnumerable<GoalDto>>(GoalService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), "Pillar, PrimaryOwner, SecondryOwner"));

            return _allGoals;
        }

        public long GetGoalCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Goal> GoalService = _dataRepositoryFactory.GetRepository<Goal>();
            return GoalService.Count(i => i.OrganizationId.Equals(_organizationId));
        }

        public IEnumerable<GoalDto> GetGoalByPillarId(long _goalPillarId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            long _pillarId = Convert.ToInt64(_goalPillarId);
            IBaseRepository<Goal> GoalService = _dataRepositoryFactory.GetRepository<Goal>();
            IEnumerable<GoalDto> _goals = Mapper.Map<IEnumerable<GoalDto>>(GoalService.GetList(c => c.PillarId == _pillarId && c.OrganizationId == _organizationId, null, "Pillar"));

            return _goals;
        }
    }
}
