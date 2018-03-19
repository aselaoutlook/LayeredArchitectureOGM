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
    [Export(typeof(ILocationService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LocationService : ILocationService
    {
        public LocationDto CreateLocation(LocationDto _location, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Location> LocationService = _dataRepositoryFactory.GetRepository<Location>();
            LocationDto _createdLocation = Mapper.Map<LocationDto>(LocationService.Add(Mapper.Map<Location>(_location)));

            return _createdLocation;
        }

        public LocationDto UpdateLocation(LocationDto _location, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Location> LocationService = _dataRepositoryFactory.GetRepository<Location>();
            LocationDto _updatedLocation = Mapper.Map<LocationDto>(LocationService.Update(Mapper.Map<Location>(_location)));

            return _updatedLocation;
        }

        public LocationDto UpdateLocation(LocationDto _location, long _locationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Location> LocationService = _dataRepositoryFactory.GetRepository<Location>();
            LocationDto _updatedLocation = Mapper.Map<LocationDto>(LocationService.Update(Mapper.Map<Location>(_location), _locationId));

            return _updatedLocation;
        }

        public LocationDto GetLocationByLocationId(long _locationId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Location> LocationService = _dataRepositoryFactory.GetRepository<Location>();
            LocationDto _location = Mapper.Map<LocationDto>(LocationService.GetSingle(l => l.LocationId.Equals(_locationId) && l.OrganizationId.Equals(_organizationId), "Country, GlobalRegion, State"));

            return _location;
        }

        public ICollection<LocationDto> GetAllLocations(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Location> LocationService = _dataRepositoryFactory.GetRepository<Location>();
            ICollection<LocationDto> _allLocations = Mapper.Map<ICollection<LocationDto>>(LocationService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allLocations;
        }

        public IEnumerable<LocationDto> GetLocationList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Location> LocationService = _dataRepositoryFactory.GetRepository<Location>();
            IEnumerable<LocationDto> _allLocations = Mapper.Map<IEnumerable<LocationDto>>(LocationService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), "Country, GlobalRegion, State"));

            return _allLocations;
        }

        public long GetLocationCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Location> LocationService = _dataRepositoryFactory.GetRepository<Location>();
            return LocationService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
