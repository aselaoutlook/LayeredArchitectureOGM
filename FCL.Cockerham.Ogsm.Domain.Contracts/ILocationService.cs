using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface ILocationService
    {
        LocationDto CreateLocation(LocationDto _location, IUnitOfWork _dataRepositoryFactory);
        LocationDto UpdateLocation(LocationDto _location, IUnitOfWork _dataRepositoryFactory);
        LocationDto UpdateLocation(LocationDto _location, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        LocationDto GetLocationByLocationId(long _locationId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<LocationDto> GetAllLocations(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<LocationDto> GetLocationList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetLocationCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
