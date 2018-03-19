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
    [Export(typeof(ICountryService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CountryService : ICountryService
    {
        public CountryDto CreateCountry(CountryDto _country, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Country> CountryService = _dataRepositoryFactory.GetRepository<Country>();
            CountryDto _createdCountry = Mapper.Map<CountryDto>(CountryService.Add(Mapper.Map<Country>(_country)));

            return _createdCountry;
        }

        public CountryDto UpdateCountry(CountryDto _country, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Country> CountryService = _dataRepositoryFactory.GetRepository<Country>();
            CountryDto _updatedCountry = Mapper.Map<CountryDto>(CountryService.Update(Mapper.Map<Country>(_country)));

            return _updatedCountry;
        }

        public CountryDto UpdateCountry(CountryDto _country, long _countryId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Country> CountryService = _dataRepositoryFactory.GetRepository<Country>();
            CountryDto _updatedCountry = Mapper.Map<CountryDto>(CountryService.Update(Mapper.Map<Country>(_country), _countryId));

            return _updatedCountry;
        }

        public CountryDto GetCountryByCountryId(long _countryId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Country> CountryService = _dataRepositoryFactory.GetRepository<Country>();
            CountryDto _country = Mapper.Map<CountryDto>(CountryService.GetSingle(c => c.OrganizationId.Equals(_organizationId) && c.CountryId.Equals(_countryId), "GlobalRegion"));

            return _country;
        }

        public ICollection<CountryDto> GetAllCountrys(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Country> CountryService = _dataRepositoryFactory.GetRepository<Country>();
            ICollection<CountryDto> _allCountrys = Mapper.Map<ICollection<CountryDto>>(CountryService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allCountrys;
        }

        public IEnumerable<CountryDto> GetCountryList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Country> CountryService = _dataRepositoryFactory.GetRepository<Country>();
            IEnumerable<CountryDto> _allCountrys = Mapper.Map<IEnumerable<CountryDto>>(CountryService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), "GlobalRegion"));

            return _allCountrys;
        }

        public IEnumerable<CountryDto> GetCountryiesByGlobalRegionId(long _regionId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Country> CountryService = _dataRepositoryFactory.GetRepository<Country>();
            IEnumerable<CountryDto> _regionCountryies = Mapper.Map<IEnumerable<CountryDto>>(CountryService.GetList(c => c.OrganizationId.Equals(_organizationId) && c.GlobalRegionId.Equals(_regionId), null, "GlobalRegion"));

            return _regionCountryies;
        }

        public long GetCountryCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Country> CountryService = _dataRepositoryFactory.GetRepository<Country>();
            return CountryService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
