using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IAppSettingBaseService
    {
        AppSettingBaseDto CreateAppSettingBase(AppSettingBaseDto _appSettingBase, IUnitOfWork _dataRepositoryFactory);
        AppSettingBaseDto UpdateAppSettingBase(AppSettingBaseDto _appSettingBase, IUnitOfWork _dataRepositoryFactory);
        AppSettingBaseDto UpdateAppSettingBase(AppSettingBaseDto _appSettingBase, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        AppSettingBaseDto GetAppSettingBaseByAppSettingBaseId(long _appSettingBaseId, IUnitOfWork _dataRepositoryFactory);
        ICollection<AppSettingBaseDto> GetAllAppSettingBases(IUnitOfWork _dataRepositoryFactory);
        IEnumerable<AppSettingBaseDto> GetAppSettingBaseList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory);
        long GetAppSettingBaseCount(IUnitOfWork _dataRepositoryFactory); 
    }
}