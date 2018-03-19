using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IBusinessUnitService
    {
        BusinessUnitDto CreateBusinessUnit(BusinessUnitDto _businessUnit, IUnitOfWork _dataRepositoryFactory);
        BusinessUnitDto UpdateBusinessUnit(BusinessUnitDto _businessUnit, IUnitOfWork _dataRepositoryFactory);
        BusinessUnitDto UpdateBusinessUnit(BusinessUnitDto _businessUnit, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        BusinessUnitDto GetBusinessUnitByBusinessUnitId(long _businessUnitId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<BusinessUnitDto> GetAllBusinessUnits(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<BusinessUnitDto> GetBusinessUnitList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetBusinessUnitCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<BusinessUnitDto> GetBusinessUnitsByStTypeId(long _stTypeId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
