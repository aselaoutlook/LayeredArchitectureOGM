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
    [Export(typeof(IDisplayNameService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DisplayNameService:IDisplayNameService
    {
        public DisplayNameDto CreateDisplayName(DisplayNameDto _displayName, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayName> DisplayNameService= _dataRepositoryFactory.GetRepository<DisplayName>();
            DisplayNameDto _createdDisplayName = Mapper.Map<DisplayNameDto>(DisplayNameService.Add(Mapper.Map<DisplayName>(_displayName)));

            return _createdDisplayName;
        }

        public DisplayNameDto UpdateDisplayName(DisplayNameDto _displayName, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayName> DisplayNameService= _dataRepositoryFactory.GetRepository<DisplayName>();
            DisplayNameDto _updatedDisplayName = Mapper.Map<DisplayNameDto>(DisplayNameService.Update(Mapper.Map<DisplayName>(_displayName)));

            return _updatedDisplayName;
        }

        public DisplayNameDto UpdateDisplayName(DisplayNameDto _displayName, long _displayNameId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayName> DisplayNameService= _dataRepositoryFactory.GetRepository<DisplayName>();
            DisplayNameDto _updatedDisplayName = Mapper.Map<DisplayNameDto>(DisplayNameService.Update(Mapper.Map<DisplayName>(_displayName), _displayNameId));

            return _updatedDisplayName;
        }

        public DisplayNameDto GetDisplayNameByDisplayNameId(long _displayNameId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayName> DisplayNameService= _dataRepositoryFactory.GetRepository<DisplayName>();
            DisplayNameDto _displayName = Mapper.Map<DisplayNameDto>(DisplayNameService.GetSingle(i => i.DisplayNameId.Equals(_displayNameId) && i.OrganizationId.Equals(_organizationId)));

            return _displayName;
        }

        public ICollection<DisplayNameDto> GetAllDisplayNames(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayName> DisplayNameService= _dataRepositoryFactory.GetRepository<DisplayName>();
            ICollection<DisplayNameDto> _allDisplayNames = Mapper.Map<ICollection<DisplayNameDto>>(DisplayNameService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allDisplayNames;
        }

        public IEnumerable<DisplayNameDto> GetDisplayNameList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayName> DisplayNameService= _dataRepositoryFactory.GetRepository<DisplayName>();
            IEnumerable<DisplayNameDto> _allDisplayNames = Mapper.Map<IEnumerable<DisplayNameDto>>(DisplayNameService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.DisplayNameId), null));

            return _allDisplayNames;
        }

        public long GetDisplayNameCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<DisplayName> DisplayNameService= _dataRepositoryFactory.GetRepository<DisplayName>();
            return DisplayNameService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}