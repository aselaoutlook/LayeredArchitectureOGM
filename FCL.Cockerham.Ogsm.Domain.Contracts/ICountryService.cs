using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface ICountryService
    {
        CountryDto CreateCountry(CountryDto _country, IUnitOfWork _dataRepositoryFactory);
        CountryDto UpdateCountry(CountryDto _country, IUnitOfWork _dataRepositoryFactory);
        CountryDto UpdateCountry(CountryDto _country, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        CountryDto GetCountryByCountryId(long _countryId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<CountryDto> GetAllCountrys(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<CountryDto> GetCountryList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<CountryDto> GetCountryiesByGlobalRegionId(long _regionId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetCountryCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
