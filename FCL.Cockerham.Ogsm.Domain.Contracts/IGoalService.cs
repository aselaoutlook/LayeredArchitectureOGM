using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IGoalService
    {
        GoalDto CreateGoal(GoalDto _goal, IUnitOfWork _dataRepositoryFactory);
        GoalDto UpdateGoal(GoalDto _goal, IUnitOfWork _dataRepositoryFactory);
        GoalDto UpdateGoal(GoalDto _goal, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        GoalDto GetGoalByGoalId(long _goalId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<GoalDto> GetAllGoals(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<GoalDto> GetGoalList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetGoalCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<GoalDto> GetGoalByPillarId(long _goalPillarId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}