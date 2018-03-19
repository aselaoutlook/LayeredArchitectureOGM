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
    [Export(typeof(IAppSettingService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AppSettingService:IAppSettingService
    {
        public AppSettingDto CreateAppSetting(AppSettingDto _appSetting, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSetting> AppSettingService = _dataRepositoryFactory.GetRepository<AppSetting>();
            AppSettingDto _createdAppSetting = Mapper.Map<AppSettingDto>(AppSettingService.Add(Mapper.Map<AppSetting>(_appSetting)));

            return _createdAppSetting;
        }

        public AppSettingDto UpdateAppSetting(AppSettingDto _appSetting, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSetting> AppSettingService = _dataRepositoryFactory.GetRepository<AppSetting>();
            AppSettingDto _updatedAppSetting = Mapper.Map<AppSettingDto>(AppSettingService.Update(Mapper.Map<AppSetting>(_appSetting)));

            return _updatedAppSetting;
        }

        public AppSettingDto UpdateAppSetting(AppSettingDto _appSetting, long _appSettingId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSetting> AppSettingService = _dataRepositoryFactory.GetRepository<AppSetting>();
            AppSettingDto _updatedAppSetting = Mapper.Map<AppSettingDto>(AppSettingService.Update(Mapper.Map<AppSetting>(_appSetting), _appSettingId));

            return _updatedAppSetting;
        }

        public AppSettingDto GetAppSettingByAppSettingId(long _appSettingId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSetting> AppSettingService = _dataRepositoryFactory.GetRepository<AppSetting>();
            AppSettingDto _appSetting = Mapper.Map<AppSettingDto>(AppSettingService.GetSingle(i => i.AppSettingId == _appSettingId && i.OrganizationId.Equals(_organizationId)));

            return _appSetting;
        }

        public ICollection<AppSettingDto> GetAllAppSettings(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSetting> AppSettingService = _dataRepositoryFactory.GetRepository<AppSetting>();
            ICollection<AppSettingDto> _allAppSettings = Mapper.Map<ICollection<AppSettingDto>>(AppSettingService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allAppSettings;
        }

        public IEnumerable<AppSettingDto> GetAppSettingList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSetting> AppSettingService = _dataRepositoryFactory.GetRepository<AppSetting>();
            IEnumerable<AppSettingDto> _allAppSettings = Mapper.Map<IEnumerable<AppSettingDto>>(AppSettingService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.AppSettingId), null));

            return _allAppSettings;
        }

        public long GetAppSettingCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSetting> AppSettingService = _dataRepositoryFactory.GetRepository<AppSetting>();
            return AppSettingService.Count(i => i.OrganizationId.Equals(_organizationId));
        } 
    }
}