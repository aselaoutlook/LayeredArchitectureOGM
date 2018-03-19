using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IStTypeService
    {
        StTypeDto CreateStType(StTypeDto _stType, IUnitOfWork _dataRepositoryFactory);
        StTypeDto UpdateStType(StTypeDto _stType, IUnitOfWork _dataRepositoryFactory);
        StTypeDto UpdateStType(StTypeDto _stType, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        StTypeDto GetStTypeByStTypeId(long _stType, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<StTypeDto> GetAllStTypes(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<StTypeDto> GetStTypeList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);

        /// <summary>
        /// Comment On 11-13-2017 By Asela
        /// Change Request By Heven: Change order of the filters in Dashboard
        /// </summary>
        //IEnumerable<StTypeDto> GetStTypesByBusinessUnitId(long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        long GetStTypeCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
