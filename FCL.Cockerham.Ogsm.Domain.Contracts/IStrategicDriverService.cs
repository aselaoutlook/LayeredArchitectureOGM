using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IStrategicDriverService
    {
        StrategicDriverDto CreateStrategicDriver(StrategicDriverDto _strategicDriver, IUnitOfWork _dataRepositoryFactory);
        StrategicDriverDto UpdateStrategicDriver(StrategicDriverDto _strategicDriver, IUnitOfWork _dataRepositoryFactory);
        StrategicDriverDto UpdateStrategicDriver(StrategicDriverDto _strategicDriver, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        StrategicDriverDto GetStrategicDriverByStrategicDriverId(long _strategicDriverId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StrategicDriverDto> GetAllStrategicDrivers(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StrategicDriverDto> GetStrategicDriverList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetStrategicDriverCount(long _organizationId,IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StrategicDriverDto> GetStrategicDriverByGoalId(long _goalId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StrategicDriverDto> GetStrategicDriverByGoalAndStrategyOwner(long _goalId, long _ownerId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StrategicDriverDto> GetStrategicDriverByStrategyOwnerId(long _ownerId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        bool CreateStrategicDriverTargetsForStrategy(StrategicDriverDto _strategicDriver, LoggedInUserDto _loggedInUser, IStrategicDriverTargetService _strategicDriverTargetDomainService, IUnitOfWork _dataRepositoryFactory);
    }
}