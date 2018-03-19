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
    [Export(typeof(IAppSettingBaseService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AppSettingBaseService:IAppSettingBaseService
    {
        public AppSettingBaseDto CreateAppSettingBase(AppSettingBaseDto _appSettingBase, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSettingBase> AppSettingBaseService = _dataRepositoryFactory.GetRepository<AppSettingBase>();
            AppSettingBaseDto _createdAppSettingBase = Mapper.Map<AppSettingBaseDto>(AppSettingBaseService.Add(Mapper.Map<AppSettingBase>(_appSettingBase)));

            return _createdAppSettingBase;
        }

        public AppSettingBaseDto UpdateAppSettingBase(AppSettingBaseDto _appSettingBase, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSettingBase> AppSettingBaseService = _dataRepositoryFactory.GetRepository<AppSettingBase>();
            AppSettingBaseDto _updatedAppSettingBase = Mapper.Map<AppSettingBaseDto>(AppSettingBaseService.Update(Mapper.Map<AppSettingBase>(_appSettingBase)));

            return _updatedAppSettingBase;
        }

        public AppSettingBaseDto UpdateAppSettingBase(AppSettingBaseDto _appSettingBase, long _appSettingBaseId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSettingBase> AppSettingBaseService = _dataRepositoryFactory.GetRepository<AppSettingBase>();
            AppSettingBaseDto _updatedAppSettingBase = Mapper.Map<AppSettingBaseDto>(AppSettingBaseService.Update(Mapper.Map<AppSettingBase>(_appSettingBase), _appSettingBaseId));

            return _updatedAppSettingBase;
        }

        public AppSettingBaseDto GetAppSettingBaseByAppSettingBaseId(long _appSettingBaseId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSettingBase> AppSettingBaseService = _dataRepositoryFactory.GetRepository<AppSettingBase>();
            AppSettingBaseDto _appSettingBase = Mapper.Map<AppSettingBaseDto>(AppSettingBaseService.GetSingle(_appSettingBaseId));

            return _appSettingBase;
        }

        public ICollection<AppSettingBaseDto> GetAllAppSettingBases(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSettingBase> AppSettingBaseService = _dataRepositoryFactory.GetRepository<AppSettingBase>();
            ICollection<AppSettingBaseDto> _allAppSettingBases = Mapper.Map<ICollection<AppSettingBaseDto>>(AppSettingBaseService.GetAll());

            return _allAppSettingBases;
        }

        public IEnumerable<AppSettingBaseDto> GetAppSettingBaseList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<AppSettingBase> AppSettingBaseService = _dataRepositoryFactory.GetRepository<AppSettingBase>();
            IEnumerable<AppSettingBaseDto> _allAppSettingBases = Mapper.Map<IEnumerable<AppSettingBaseDto>>(AppSettingBaseService.GetPagedList(pageNo, pageSize, null, q => q.OrderBy(s => s.AppSettingBaseId), null));

            return _allAppSettingBases;
        }

        public long GetAppSettingBaseCount(IUnitOfWork _dataRepositoryFactory)
        {
            IAppSettingBaseRepository AppSettingBaseService = _dataRepositoryFactory.GetAppSettingBaseRepository();
            return AppSettingBaseService.Count();
        }
    }
}