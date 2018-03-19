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
    [Export(typeof(IDisplayBaseService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DisplayBaseService:IDisplayBaseService
    {
        public DisplayBaseDto CreateDisplayBase(DisplayBaseDto _displayBase, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayBase> DisplayBaseService = _dataRepositoryFactory.GetRepository<DisplayBase>();
            DisplayBaseDto _createdDisplayBase = Mapper.Map<DisplayBaseDto>(DisplayBaseService.Add(Mapper.Map<DisplayBase>(_displayBase)));

            return _createdDisplayBase;
        }

        public DisplayBaseDto UpdateDisplayBase(DisplayBaseDto _displayBase, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayBase> DisplayBaseService = _dataRepositoryFactory.GetRepository<DisplayBase>();
            DisplayBaseDto _updatedDisplayBase = Mapper.Map<DisplayBaseDto>(DisplayBaseService.Update(Mapper.Map<DisplayBase>(_displayBase)));

            return _updatedDisplayBase;
        }

        public DisplayBaseDto UpdateDisplayBase(DisplayBaseDto _displayBase, long _displayBaseId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayBase> DisplayBaseService = _dataRepositoryFactory.GetRepository<DisplayBase>();
            DisplayBaseDto _updatedDisplayBase = Mapper.Map<DisplayBaseDto>(DisplayBaseService.Update(Mapper.Map<DisplayBase>(_displayBase), _displayBaseId));

            return _updatedDisplayBase;
        }

        public DisplayBaseDto GetDisplayBaseByDisplayBaseId(long _displayBaseId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayBase> DisplayBaseService = _dataRepositoryFactory.GetRepository<DisplayBase>();
            DisplayBaseDto _displayBase = Mapper.Map<DisplayBaseDto>(DisplayBaseService.GetSingle(_displayBaseId));

            return _displayBase;
        }

        public ICollection<DisplayBaseDto> GetAllDisplayBases(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayBase> DisplayBaseService = _dataRepositoryFactory.GetRepository<DisplayBase>();
            ICollection<DisplayBaseDto> _allDisplayBases = Mapper.Map<ICollection<DisplayBaseDto>>(DisplayBaseService.GetAll());

            return _allDisplayBases;
        }

        public IEnumerable<DisplayBaseDto> GetDisplayBaseList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayBase> DisplayBaseService = _dataRepositoryFactory.GetRepository<DisplayBase>();
            IEnumerable<DisplayBaseDto> _allDisplayBases = Mapper.Map<IEnumerable<DisplayBaseDto>>(DisplayBaseService.GetPagedList(pageNo, pageSize, null, q => q.OrderBy(s => s.DisplayBaseId), null));

            return _allDisplayBases;
        }

        public long GetDisplayBaseCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayBase> DisplayBaseService = _dataRepositoryFactory.GetRepository<DisplayBase>();
            return DisplayBaseService.Count();
        }
    }
}