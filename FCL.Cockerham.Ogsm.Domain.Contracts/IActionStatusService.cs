using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IActionStatusService
    {
        ActionStatusDto CreateActionStatus(ActionStatusDto _actionStatus, IUnitOfWork _dataRepositoryFactory);
        ActionStatusDto UpdateActionStatus(ActionStatusDto _actionStatus, IUnitOfWork _dataRepositoryFactory);
        ActionStatusDto UpdateActionStatus(ActionStatusDto _actionStatus, long _actionStatusId, IUnitOfWork _dataRepositoryFactory);
        ActionStatusDto GetActionStatusByActionStatusId(long _actionStatusId, IUnitOfWork _dataRepositoryFactory);
        ICollection<ActionStatusDto> GetAllActionStatus(IUnitOfWork _dataRepositoryFactory);
        IEnumerable<ActionStatusDto> GetActionStatusList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory);
        long GetActionStatusCount(IUnitOfWork _dataRepositoryFactory);
    }
}
