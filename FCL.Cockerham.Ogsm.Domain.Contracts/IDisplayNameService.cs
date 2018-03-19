using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IDisplayNameService
    {
        DisplayNameDto CreateDisplayName(DisplayNameDto _displayName, IUnitOfWork _dataRepositoryFactory);
        DisplayNameDto UpdateDisplayName(DisplayNameDto _displayName, IUnitOfWork _dataRepositoryFactory);
        DisplayNameDto UpdateDisplayName(DisplayNameDto _displayName, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        DisplayNameDto GetDisplayNameByDisplayNameId(long _displayNameId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<DisplayNameDto> GetAllDisplayNames(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<DisplayNameDto> GetDisplayNameList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetDisplayNameCount(long _organizationId, IUnitOfWork _dataRepositoryFactory); 
    }
}