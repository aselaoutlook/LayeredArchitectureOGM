using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IPillarService
    {
        PillarDto CreatePillar(PillarDto _pillar, IUnitOfWork _dataRepositoryFactory);
        PillarDto UpdatePillar(PillarDto _pillar, IUnitOfWork _dataRepositoryFactory);
        PillarDto UpdatePillar(PillarDto _pillar, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        PillarDto GetPillarByPillarId(long _pillarId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<PillarDto> GetAllPillars(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<PillarDto> GetPillarList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetPillarCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<PillarDto> GetPillarsByStTypeId(long _stTypeId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
