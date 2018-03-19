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
    [Export(typeof(IOrganizationService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrganizationService:IOrganizationService
    {
        public OrganizationDto CreateOrganization(OrganizationDto _organization, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            OrganizationDto _createdOrganization = Mapper.Map<OrganizationDto>(OrganizationService.Add(Mapper.Map<Organization>(_organization)));

            return _createdOrganization;
        }

        public OrganizationDto UpdateOrganization(OrganizationDto _organization, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            OrganizationDto _updatedOrganization = Mapper.Map<OrganizationDto>(OrganizationService.Update(Mapper.Map<Organization>(_organization)));

            return _updatedOrganization;
        }

        public OrganizationDto UpdateOrganization(OrganizationDto _organization, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            OrganizationDto _updatedOrganization = Mapper.Map<OrganizationDto>(OrganizationService.Update(Mapper.Map<Organization>(_organization), _organizationId));

            return _updatedOrganization;
        }

        public OrganizationDto GetOrganizationByOrganizationId(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            OrganizationDto _organization = Mapper.Map<OrganizationDto>(OrganizationService.GetSingle(_organizationId));

            return _organization;
        }

        public ICollection<OrganizationDto> GetAllOrganizations(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            ICollection<OrganizationDto> _allOrganizations = Mapper.Map<ICollection<OrganizationDto>>(OrganizationService.GetAll());

            return _allOrganizations;
        }

        public IEnumerable<OrganizationDto> GetOrganizationList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            IEnumerable<OrganizationDto> _allOrganizations = Mapper.Map<IEnumerable<OrganizationDto>>(OrganizationService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), null));

            return _allOrganizations;
        }

        public long GetOrganizationCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            return OrganizationService.Count(i => i.OrganizationId.Equals(_organizationId));
        }

        public ICollection<OrganizationDto> GetActiveOrganizations(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            ICollection<OrganizationDto> _activeOrganizations = Mapper.Map<ICollection<OrganizationDto>>(OrganizationService.GetListWithNavigation(i => i.IsActive.Equals(true)));

            return _activeOrganizations;
        }

        public void DeleteOrganization(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Organization> OrganizationService = _dataRepositoryFactory.GetRepository<Organization>();
            OrganizationService.Delete(_organizationId);
        }

        public IEnumerable<OrganizationDto> GetFilteredOrganizationListByOrgName(string _orgName, IUnitOfWork _dataRepositoryFactory)
        {
            IOrganizationRepository OrgRepo = _dataRepositoryFactory.GetOrganizationRepository();
            IEnumerable<OrganizationDto> _allFilteredOrgs = Mapper.Map<IEnumerable<OrganizationDto>>(OrgRepo.GetList(i => i.Name.Contains(_orgName), null, ""));

            return _allFilteredOrgs;
        }
    }
}