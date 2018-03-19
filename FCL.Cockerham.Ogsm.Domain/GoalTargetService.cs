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
    [Export(typeof(IGoalTargetService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GoalTargetService : IGoalTargetService
    {
        public GoalTargetDto CreateGoalTarget(GoalTargetDto _goalTarget, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalTarget> GoalTargetService = _dataRepositoryFactory.GetRepository<GoalTarget>();
            GoalTargetDto _createdGoalTarget = Mapper.Map<GoalTargetDto>(GoalTargetService.Add(Mapper.Map<GoalTarget>(_goalTarget)));

            return _createdGoalTarget;
        }

        public GoalTargetDto UpdateGoalTarget(GoalTargetDto _goalTarget, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalTarget> GoalTargetService = _dataRepositoryFactory.GetRepository<GoalTarget>();
            GoalTargetDto _updatedGoalTarget = Mapper.Map<GoalTargetDto>(GoalTargetService.Update(Mapper.Map<GoalTarget>(_goalTarget)));

            return _updatedGoalTarget;
        }

        public GoalTargetDto UpdateGoalTarget(GoalTargetDto _goalTarget, long _goalTargetId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalTarget> GoalTargetService = _dataRepositoryFactory.GetRepository<GoalTarget>();
            GoalTargetDto _updatedGoalTarget = Mapper.Map<GoalTargetDto>(GoalTargetService.Update(Mapper.Map<GoalTarget>(_goalTarget), _goalTargetId));

            return _updatedGoalTarget;
        }

        public GoalTargetDto GetGoalTargetByGoalTargetId(long _goalTargetId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalTarget> GoalTargetService = _dataRepositoryFactory.GetRepository<GoalTarget>();
            GoalTargetDto _goalTarget = Mapper.Map<GoalTargetDto>(GoalTargetService.GetSingle(i => i.GoalTargetId.Equals(_goalTargetId) && i.OrganizationId.Equals(_organizationId)));

            return _goalTarget;
        }

        public ICollection<GoalTargetDto> GetAllGoalTargets(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalTarget> GoalTargetService = _dataRepositoryFactory.GetRepository<GoalTarget>();
            ICollection<GoalTargetDto> _allGoalTargets = Mapper.Map<ICollection<GoalTargetDto>>(GoalTargetService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allGoalTargets;
        }

        public IEnumerable<GoalTargetDto> GetGoalTargetList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalTarget> GoalTargetService = _dataRepositoryFactory.GetRepository<GoalTarget>();
            IEnumerable<GoalTargetDto> _allGoalTargets = Mapper.Map<IEnumerable<GoalTargetDto>>(GoalTargetService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.YearValue), null));

            return _allGoalTargets;
        }

        public long GetGoalTargetCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GoalTarget> GoalTargetService = _dataRepositoryFactory.GetRepository<GoalTarget>();
            return GoalTargetService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}