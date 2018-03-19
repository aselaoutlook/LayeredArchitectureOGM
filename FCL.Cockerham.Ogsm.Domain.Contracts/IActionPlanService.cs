using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IActionPlanService
    {
        ActionPlanDto CreateActionPlan(ActionPlanDto _actionPlan, IUnitOfWork _dataRepositoryFactory);
        ActionPlanDto UpdateActionPlan(ActionPlanDto _actionPlan, IUnitOfWork _dataRepositoryFactory);
        ActionPlanDto UpdateActionPlan(ActionPlanDto _actionPlan, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        ActionPlanDto GetActionPlanByActionPlanId(long _actionPlanId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<ActionPlanDto> GetAllActionPlans(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<ActionPlanDto> GetActionPlanList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<ActionPlanDto> GetAllActionPlansByStrategicDriverId(int pageNo, int pageSize, long SdId, long OrgId, IUnitOfWork _dataRepositoryFactory);
        long GetActionPlanCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ActionPlanDto GetActionPlanByActionPlanIdAsTrackable(long _actionPlanId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<ActionPlanDto> GetActionPlansByStrategicDriverId(long _strategicDriverId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}