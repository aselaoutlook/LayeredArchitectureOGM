using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IDisplayBaseService
    {
        DisplayBaseDto CreateDisplayBase(DisplayBaseDto _displayBase, IUnitOfWork _dataRepositoryFactory);
        DisplayBaseDto UpdateDisplayBase(DisplayBaseDto _displayBase, IUnitOfWork _dataRepositoryFactory);
        DisplayBaseDto UpdateDisplayBase(DisplayBaseDto _displayBase, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        DisplayBaseDto GetDisplayBaseByDisplayBaseId(long _displayBaseId, IUnitOfWork _dataRepositoryFactory);
        ICollection<DisplayBaseDto> GetAllDisplayBases(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<DisplayBaseDto> GetDisplayBaseList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetDisplayBaseCount(long _organizationId, IUnitOfWork _dataRepositoryFactory); 
    }
}