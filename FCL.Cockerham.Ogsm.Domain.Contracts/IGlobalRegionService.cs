using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IGlobalRegionService
    {
        GlobalRegionDto CreateGlobalRegion(GlobalRegionDto _GlobalRegion, IUnitOfWork _dataRepositoryFactory);
        GlobalRegionDto UpdateGlobalRegion(GlobalRegionDto _GlobalRegion, IUnitOfWork _dataRepositoryFactory);
        GlobalRegionDto UpdateGlobalRegion(GlobalRegionDto _GlobalRegion, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        GlobalRegionDto GetGlobalRegionByGlobalRegionId(long _GlobalRegionId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<GlobalRegionDto> GetAllGlobalRegions(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<GlobalRegionDto> GetGlobalRegionList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetGlobalRegionCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
