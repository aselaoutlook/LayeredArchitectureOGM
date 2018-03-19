using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IStateService
    {
        StateDto CreateState(StateDto _state, IUnitOfWork _dataRepositoryFactory);
        StateDto UpdateState(StateDto _state, IUnitOfWork _dataRepositoryFactory);
        StateDto UpdateState(StateDto _state, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        StateDto GetStateByStateId(long _stateId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<StateDto> GetAllStates(IUnitOfWork _dataRepositoryFactory);
        ICollection<StateDto> GetAllStates(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StateDto> GetStateList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StateDto> GetStatesByCountryId(long _countryId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetStateCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
