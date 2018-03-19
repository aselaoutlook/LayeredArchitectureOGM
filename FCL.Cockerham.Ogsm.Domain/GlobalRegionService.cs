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
    [Export(typeof(IGlobalRegionService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GlobalRegionService : IGlobalRegionService
    {
        public GlobalRegionDto CreateGlobalRegion(GlobalRegionDto _globalRegion, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GlobalRegion> GlobalRegionService = _dataRepositoryFactory.GetRepository<GlobalRegion>();
            GlobalRegionDto _createdGlobalRegion = Mapper.Map<GlobalRegionDto>(GlobalRegionService.Add(Mapper.Map<GlobalRegion>(_globalRegion)));

            return _createdGlobalRegion;
        }

        public GlobalRegionDto UpdateGlobalRegion(GlobalRegionDto _globalRegion, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GlobalRegion> GlobalRegionService = _dataRepositoryFactory.GetRepository<GlobalRegion>();
            GlobalRegionDto _updatedGlobalRegion = Mapper.Map<GlobalRegionDto>(GlobalRegionService.Update(Mapper.Map<GlobalRegion>(_globalRegion)));

            return _updatedGlobalRegion;
        }

        public GlobalRegionDto UpdateGlobalRegion(GlobalRegionDto _globalRegion, long _globalRegionId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GlobalRegion> GlobalRegionService = _dataRepositoryFactory.GetRepository<GlobalRegion>();
            GlobalRegionDto _updatedGlobalRegion = Mapper.Map<GlobalRegionDto>(GlobalRegionService.Update(Mapper.Map<GlobalRegion>(_globalRegion), _globalRegionId));

            return _updatedGlobalRegion;
        }

        public GlobalRegionDto GetGlobalRegionByGlobalRegionId(long _globalRegionId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GlobalRegion> GlobalRegionService = _dataRepositoryFactory.GetRepository<GlobalRegion>();
            GlobalRegionDto _globalRegion = Mapper.Map<GlobalRegionDto>(GlobalRegionService.GetSingle(i => i.GlobalRegionId.Equals(_globalRegionId) && i.OrganizationId.Equals(_organizationId)));

            return _globalRegion;
        }

        public IEnumerable<GlobalRegionDto> GetAllGlobalRegions(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GlobalRegion> GlobalRegionService = _dataRepositoryFactory.GetRepository<GlobalRegion>();
            IEnumerable<GlobalRegionDto> _allGlobalRegions = Mapper.Map<IEnumerable<GlobalRegionDto>>(GlobalRegionService.GetList(i => i.OrganizationId.Equals(_organizationId)));

            return _allGlobalRegions;
        }

        public IEnumerable<GlobalRegionDto> GetGlobalRegionList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GlobalRegion> GlobalRegionService = _dataRepositoryFactory.GetRepository<GlobalRegion>();
            IEnumerable<GlobalRegionDto> _allGlobalRegions = Mapper.Map<IEnumerable<GlobalRegionDto>>(GlobalRegionService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), null));

            return _allGlobalRegions;
        }

        public long GetGlobalRegionCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<GlobalRegion> GlobalRegionService = _dataRepositoryFactory.GetRepository<GlobalRegion>();
            return GlobalRegionService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
