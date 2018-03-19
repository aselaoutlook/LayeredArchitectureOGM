using AutoMapper;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IActionStatusService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActionStatusService : IActionStatusService
    {
        public ActionStatusDto CreateActionStatus(ActionStatusDto _actionStatus, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionStatus> ActionStatusService = _dataRepositoryFactory.GetRepository<ActionStatus>();
            ActionStatusDto _createdActionStatus = Mapper.Map<ActionStatusDto>(ActionStatusService.Add(Mapper.Map<ActionStatus>(_actionStatus)));

            return _createdActionStatus;
        }

        public ActionStatusDto UpdateActionStatus(ActionStatusDto _actionStatus, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionStatus> ActionStatusService = _dataRepositoryFactory.GetRepository<ActionStatus>();
            ActionStatusDto _updatedActionStatus = Mapper.Map<ActionStatusDto>(ActionStatusService.Update(Mapper.Map<ActionStatus>(_actionStatus)));

            return _updatedActionStatus;
        }

        public ActionStatusDto UpdateActionStatus(ActionStatusDto _actionStatus, long _actionStatusId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionStatus> ActionStatusService = _dataRepositoryFactory.GetRepository<ActionStatus>();
            ActionStatusDto _updatedActionStatus = Mapper.Map<ActionStatusDto>(ActionStatusService.Update(Mapper.Map<ActionStatus>(_actionStatus), _actionStatusId));

            return _updatedActionStatus;
        }

        public ActionStatusDto GetActionStatusByActionStatusId(long _actionStatusId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionStatus> ActionStatusService = _dataRepositoryFactory.GetRepository<ActionStatus>();
            ActionStatusDto _actionStatus = Mapper.Map<ActionStatusDto>(ActionStatusService.GetSingle(_actionStatusId));

            return _actionStatus;
        }

        public ICollection<ActionStatusDto> GetAllActionStatus(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionStatus> ActionStatusService = _dataRepositoryFactory.GetRepository<ActionStatus>();
            ICollection<ActionStatusDto> _allActionStatuss = Mapper.Map<ICollection<ActionStatusDto>>(ActionStatusService.GetAll());

            return _allActionStatuss;
        }

        public IEnumerable<ActionStatusDto> GetActionStatusList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionStatus> ActionStatusService = _dataRepositoryFactory.GetRepository<ActionStatus>();
            IEnumerable<ActionStatusDto> _allActionStatuss = Mapper.Map<IEnumerable<ActionStatusDto>>(ActionStatusService.GetPagedList(pageNo, pageSize, null, q => q.OrderBy(s => s.Status), null));

            return _allActionStatuss;
        }

        public long GetActionStatusCount(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionStatus> ActionStatusService = _dataRepositoryFactory.GetRepository<ActionStatus>();
            return ActionStatusService.Count();
        }
    }
}
