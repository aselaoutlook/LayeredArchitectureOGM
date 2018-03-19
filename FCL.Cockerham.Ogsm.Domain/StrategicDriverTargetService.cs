using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using AutoMapper;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IStrategicDriverTargetService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StrategicDriverTargetService : IStrategicDriverTargetService
    {
        public StrategicDriverTargetDto CreateStrategicDriverTarget(StrategicDriverTargetDto _strategicDriverTarget, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriverTarget> StrategicDriverTargetService = _dataRepositoryFactory.GetRepository<StrategicDriverTarget>();
            StrategicDriverTargetDto _createdStrategicDriverTarget = Mapper.Map<StrategicDriverTargetDto>(StrategicDriverTargetService.Add(Mapper.Map<StrategicDriverTarget>(_strategicDriverTarget)));

            return _createdStrategicDriverTarget;
        }

        public StrategicDriverTargetDto UpdateStrategicDriverTarget(StrategicDriverTargetDto _strategicDriverTarget, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriverTarget> StrategicDriverTargetService = _dataRepositoryFactory.GetRepository<StrategicDriverTarget>();
            StrategicDriverTargetDto _updatedStrategicDriverTarget = Mapper.Map<StrategicDriverTargetDto>(StrategicDriverTargetService.Update(Mapper.Map<StrategicDriverTarget>(_strategicDriverTarget)));

            return _updatedStrategicDriverTarget;
        }

        public StrategicDriverTargetDto UpdateStrategicDriverTarget(StrategicDriverTargetDto _strategicDriverTarget, long _strategicDriverTargetId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriverTarget> StrategicDriverTargetService = _dataRepositoryFactory.GetRepository<StrategicDriverTarget>();
            StrategicDriverTargetDto _updatedStrategicDriverTarget = Mapper.Map<StrategicDriverTargetDto>(StrategicDriverTargetService.Update(Mapper.Map<StrategicDriverTarget>(_strategicDriverTarget), _strategicDriverTargetId));

            return _updatedStrategicDriverTarget;
        }

        public StrategicDriverTargetDto GetStrategicDriverTargetByStrategicDriverTargetId(long _strategicDriverTargetId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriverTarget> StrategicDriverTargetService = _dataRepositoryFactory.GetRepository<StrategicDriverTarget>();
            StrategicDriverTargetDto _strategicDriverTarget = Mapper.Map<StrategicDriverTargetDto>(StrategicDriverTargetService.GetSingle(i => i.StrategicDriverTargetId.Equals(_strategicDriverTargetId) && i.OrganizationId.Equals(_organizationId)));

            return _strategicDriverTarget;
        }

        public ICollection<StrategicDriverTargetDto> GetAllStrategicDriverTargets(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriverTarget> StrategicDriverTargetService = _dataRepositoryFactory.GetRepository<StrategicDriverTarget>();
            ICollection<StrategicDriverTargetDto> _allStrategicDriverTargets = Mapper.Map<ICollection<StrategicDriverTargetDto>>(StrategicDriverTargetService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allStrategicDriverTargets;
        }

        public IEnumerable<StrategicDriverTargetDto> GetStrategicDriverTargetList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriverTarget> StrategicDriverTargetService = _dataRepositoryFactory.GetRepository<StrategicDriverTarget>();
            IEnumerable<StrategicDriverTargetDto> _allStrategicDriverTargets = Mapper.Map<IEnumerable<StrategicDriverTargetDto>>(StrategicDriverTargetService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.QuaterName), null));

            return _allStrategicDriverTargets;
        }

        public long GetStrategicDriverTargetCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriverTarget> StrategicDriverTargetService = _dataRepositoryFactory.GetRepository<StrategicDriverTarget>();
            return StrategicDriverTargetService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
