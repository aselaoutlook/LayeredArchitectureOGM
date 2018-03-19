using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using System;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using AutoMapper;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IActionPlanService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActionPlanService : IActionPlanService
    {
        public ActionPlanDto CreateActionPlan(ActionPlanDto _actionPlan, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            ActionPlanDto _createdActionPlan = Mapper.Map<ActionPlanDto>(ActionPlanService.Add(Mapper.Map<ActionPlan>(_actionPlan)));

            return _createdActionPlan;
        }

        public ActionPlanDto UpdateActionPlan(ActionPlanDto _actionPlan, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            ActionPlanDto _updatedActionPlan = Mapper.Map<ActionPlanDto>(ActionPlanService.Update(Mapper.Map<ActionPlan>(_actionPlan)));

            return _updatedActionPlan;
        }

        public ActionPlanDto UpdateActionPlan(ActionPlanDto _actionPlan, long _actionPlanId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            ActionPlanDto _updatedActionPlan = Mapper.Map<ActionPlanDto>(ActionPlanService.Update(Mapper.Map<ActionPlan>(_actionPlan), _actionPlanId));

            return _updatedActionPlan;
        }

        public ActionPlanDto GetActionPlanByActionPlanId(long _actionPlanId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            ActionPlanDto _actionPlan =
                Mapper.Map<ActionPlanDto>(ActionPlanService.GetSingle(s => s.ActionPlanId.Equals(_actionPlanId) && s.OrganizationId.Equals(_organizationId),
                    "Goal, Pillar, ActionPlanOwner,StrategicDriver,ActionPlanComments,CalendarEvents"));

            return _actionPlan;
        }

        public IEnumerable<ActionPlanDto> GetAllActionPlansByStrategicDriverId(int pageNo, int pageSize, long SdId, long OrgId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            IEnumerable<ActionPlanDto> _allActionPlans = Mapper.Map<IEnumerable<ActionPlanDto>>(ActionPlanService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(OrgId) && i.StrategicDriverId == SdId, q => q.OrderBy(s => s.Name), "Goal, Pillar, ActionPlanOwner,StrategicDriver,ActionPlanComments,CalendarEvents"));

            return _allActionPlans;
        }

        public ICollection<ActionPlanDto> GetAllActionPlans(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            ICollection<ActionPlanDto> _allActionPlans = Mapper.Map<ICollection<ActionPlanDto>>(ActionPlanService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allActionPlans;
        }

        public IEnumerable<ActionPlanDto> GetActionPlanList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            IEnumerable<ActionPlanDto> _allActionPlans = Mapper.Map<IEnumerable<ActionPlanDto>>(ActionPlanService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), "Goal, Pillar, ActionPlanOwner,StrategicDriver,ActionPlanComments,CalendarEvents"));

            return _allActionPlans;
        }

        public long GetActionPlanCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            return ActionPlanService.Count(i => i.OrganizationId.Equals(_organizationId));
        }

        public ActionPlanDto GetActionPlanByActionPlanIdAsTrackable(long _actionPlanId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            ActionPlanDto _actionPlan = Mapper.Map<ActionPlanDto>(ActionPlanService.GetSingleAsTrackable(u => u.ActionPlanId.Equals(_actionPlanId) && u.OrganizationId.Equals(_organizationId), "ActionPlanComments, CalendarEvents"));

            return _actionPlan;
        }

        public IEnumerable<ActionPlanDto> GetActionPlansByStrategicDriverId(long _strategicDriverId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlan> ActionPlanService = _dataRepositoryFactory.GetRepository<ActionPlan>();
            IEnumerable<ActionPlanDto> _actionPlans = Mapper.Map<IEnumerable<ActionPlanDto>>(ActionPlanService.GetList(c => c.StrategicDriverId == _strategicDriverId && c.OrganizationId.Equals(_organizationId), null, "Goal, Pillar, ActionPlanOwner, StrategicDriver, ActionPlanComments, CalendarEvents, ActionStatus"));
            return _actionPlans;
        }
    }
}