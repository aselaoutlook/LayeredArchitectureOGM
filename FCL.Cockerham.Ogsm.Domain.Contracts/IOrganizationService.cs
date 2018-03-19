using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IOrganizationService
    {
        OrganizationDto CreateOrganization(OrganizationDto _organization, IUnitOfWork _dataRepositoryFactory);
        OrganizationDto UpdateOrganization(OrganizationDto _organization, IUnitOfWork _dataRepositoryFactory);
        OrganizationDto UpdateOrganization(OrganizationDto _organization, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        OrganizationDto GetOrganizationByOrganizationId(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<OrganizationDto> GetAllOrganizations(IUnitOfWork _dataRepositoryFactory);
        IEnumerable<OrganizationDto> GetOrganizationList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetOrganizationCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<OrganizationDto> GetActiveOrganizations(IUnitOfWork _dataRepositoryFactory);
        void DeleteOrganization(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<OrganizationDto> GetFilteredOrganizationListByOrgName(string _orgName, IUnitOfWork _dataRepositoryFactory);
    }
}