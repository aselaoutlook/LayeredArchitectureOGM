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
    [Export(typeof(IPillarService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PillarService : IPillarService
    {
        public PillarDto CreatePillar(PillarDto _pillar, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Pillar> PillarService = _dataRepositoryFactory.GetRepository<Pillar>();
            PillarDto _createdPillar = Mapper.Map<PillarDto>(PillarService.Add(Mapper.Map<Pillar>(_pillar)));

            return _createdPillar;
        }

        public PillarDto UpdatePillar(PillarDto _pillar, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Pillar> PillarService = _dataRepositoryFactory.GetRepository<Pillar>();
            PillarDto _updatedPillar = Mapper.Map<PillarDto>(PillarService.Update(Mapper.Map<Pillar>(_pillar)));

            return _updatedPillar;
        }

        public PillarDto UpdatePillar(PillarDto _pillar, long _pillarId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Pillar> PillarService = _dataRepositoryFactory.GetRepository<Pillar>();
            PillarDto _updatedPillar = Mapper.Map<PillarDto>(PillarService.Update(Mapper.Map<Pillar>(_pillar), _pillarId));

            return _updatedPillar;
        }

        public PillarDto GetPillarByPillarId(long _pillarId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Pillar> PillarService = _dataRepositoryFactory.GetRepository<Pillar>();
            PillarDto _pillar = Mapper.Map<PillarDto>(PillarService.GetSingle(c => c.PillarId.Equals(_pillarId) && c.OrganizationId.Equals(_organizationId), "StType"));

            return _pillar;
        }

        public ICollection<PillarDto> GetAllPillars(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Pillar> PillarService = _dataRepositoryFactory.GetRepository<Pillar>();
            ICollection<PillarDto> _allPillars = Mapper.Map<ICollection<PillarDto>>(PillarService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allPillars;
        }

        public IEnumerable<PillarDto> GetPillarList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Pillar> PillarService = _dataRepositoryFactory.GetRepository<Pillar>();
            IEnumerable<PillarDto> _allPillars = Mapper.Map<IEnumerable<PillarDto>>(PillarService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), "StType"));

            return _allPillars;
        }

        public IEnumerable<PillarDto> GetPillarsByStTypeId(long _stTypeId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Pillar> PillarService = _dataRepositoryFactory.GetRepository<Pillar>();
            IEnumerable<PillarDto> _stTypePillers = Mapper.Map<IEnumerable<PillarDto>>(PillarService.GetList(c => c.StTypeId == (_stTypeId) && c.OrganizationId.Equals(_organizationId), null, "StType"));

            return _stTypePillers;
        }

        public long GetPillarCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Pillar> PillarService = _dataRepositoryFactory.GetRepository<Pillar>();
            return PillarService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
