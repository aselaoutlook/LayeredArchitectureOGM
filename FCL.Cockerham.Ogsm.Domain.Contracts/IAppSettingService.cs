using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IAppSettingService
    {
        AppSettingDto CreateAppSetting(AppSettingDto _appSetting, IUnitOfWork _dataRepositoryFactory);
        AppSettingDto UpdateAppSetting(AppSettingDto _appSetting, IUnitOfWork _dataRepositoryFactory);
        AppSettingDto UpdateAppSetting(AppSettingDto _appSetting, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        AppSettingDto GetAppSettingByAppSettingId(long _appSettingId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<AppSettingDto> GetAllAppSettings(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<AppSettingDto> GetAppSettingList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetAppSettingCount(long _organizationId, IUnitOfWork _dataRepositoryFactory); 
    }
}