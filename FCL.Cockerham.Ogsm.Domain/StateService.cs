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
    [Export(typeof(IStateService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StateService : IStateService
    {
        public StateDto CreateState(StateDto _state, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            StateDto _createdState = Mapper.Map<StateDto>(StateService.Add(Mapper.Map<State>(_state)));

            return _createdState;
        }

        public StateDto UpdateState(StateDto _state, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            StateDto _updatedState = Mapper.Map<StateDto>(StateService.Update(Mapper.Map<State>(_state)));

            return _updatedState;
        }

        public StateDto UpdateState(StateDto _state, long _stateId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            StateDto _updatedState = Mapper.Map<StateDto>(StateService.Update(Mapper.Map<State>(_state), _stateId));

            return _updatedState;
        }

        public StateDto GetStateByStateId(long _stateId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            StateDto _state = Mapper.Map<StateDto>(StateService.GetSingle(s => s.StateId.Equals(_stateId) && s.OrganizationId.Equals(_organizationId), "Country.GlobalRegion"));

            return _state;
        }

        public ICollection<StateDto> GetAllStates(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            ICollection<StateDto> _allStates = Mapper.Map<ICollection<StateDto>>(StateService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allStates;
        }

        public ICollection<StateDto> GetAllStates(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            ICollection<StateDto> _allStates = Mapper.Map<ICollection<StateDto>>(StateService.GetAll());

            return _allStates;
        }

        public IEnumerable<StateDto> GetStateList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            IEnumerable<StateDto> _allStates = Mapper.Map<IEnumerable<StateDto>>(StateService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.StateName), "Country.GlobalRegion"));

            return _allStates;
        }

        public IEnumerable<StateDto> GetStatesByCountryId(long _countryId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            IEnumerable<StateDto> _countryStates = Mapper.Map<IEnumerable<StateDto>>(StateService.GetList(c => c.CountryId.Equals(_countryId) && c.OrganizationId.Equals(_organizationId), null, "Country.GlobalRegion"));

            return _countryStates;
        }

        public long GetStateCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<State> StateService = _dataRepositoryFactory.GetRepository<State>();
            return StateService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
