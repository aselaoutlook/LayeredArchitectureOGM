using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;


namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IStrategicDriverTargetService
    {
        StrategicDriverTargetDto CreateStrategicDriverTarget(StrategicDriverTargetDto _strategicDriverTarget, IUnitOfWork _dataRepositoryFactory);
        StrategicDriverTargetDto UpdateStrategicDriverTarget(StrategicDriverTargetDto _strategicDriverTarget, IUnitOfWork _dataRepositoryFactory);
        StrategicDriverTargetDto UpdateStrategicDriverTarget(StrategicDriverTargetDto _strategicDriverTarget, long _strategicDriverId, IUnitOfWork _dataRepositoryFactory);
        StrategicDriverTargetDto GetStrategicDriverTargetByStrategicDriverTargetId(long _strategicDriverTargetId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<StrategicDriverTargetDto> GetAllStrategicDriverTargets(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StrategicDriverTargetDto> GetStrategicDriverTargetList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetStrategicDriverTargetCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        
    }
}
