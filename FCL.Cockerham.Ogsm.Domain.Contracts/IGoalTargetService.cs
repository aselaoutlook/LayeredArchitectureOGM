using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IGoalTargetService
    {
        GoalTargetDto CreateGoalTarget(GoalTargetDto _goalTarget, IUnitOfWork _dataRepositoryFactory);
        GoalTargetDto UpdateGoalTarget(GoalTargetDto _goalTarget, IUnitOfWork _dataRepositoryFactory);
        GoalTargetDto UpdateGoalTarget(GoalTargetDto _goalTarget, long _goalTargetId, IUnitOfWork _dataRepositoryFactory);
        GoalTargetDto GetGoalTargetByGoalTargetId(long _goalTargetId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<GoalTargetDto> GetAllGoalTargets(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<GoalTargetDto> GetGoalTargetList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetGoalTargetCount(long _organizationId, IUnitOfWork _dataRepositoryFactory); 
    }
}