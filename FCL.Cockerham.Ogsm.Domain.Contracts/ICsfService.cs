using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface ICsfService
    {
        CsfDto CreateCsf(CsfDto _csf, IUnitOfWork _dataRepositoryFactory);
        CsfDto UpdateCsf(CsfDto _csf, IUnitOfWork _dataRepositoryFactory);
        CsfDto UpdateCsf(CsfDto _csf, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        CsfDto GetCsfByCsfId(long _csfId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<CsfDto> GetAllCsfs(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<CsfDto> GetCsfList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetCsfCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<CsfDto> GetCsfByStTypeId(long _stTypeId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
