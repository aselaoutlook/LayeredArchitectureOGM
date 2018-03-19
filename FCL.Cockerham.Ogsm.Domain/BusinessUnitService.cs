using AutoMapper;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IBusinessUnitService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BusinessUnitService : IBusinessUnitService
    {
        public BusinessUnitDto CreateBusinessUnit(BusinessUnitDto _businessUnit, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<BusinessUnit> BusinessUnitService = _dataRepositoryFactory.GetRepository<BusinessUnit>();
            BusinessUnitDto _createdBusinessUnit = Mapper.Map<BusinessUnitDto>(BusinessUnitService.Add(Mapper.Map<BusinessUnit>(_businessUnit)));

            return _createdBusinessUnit;
        }

        public BusinessUnitDto UpdateBusinessUnit(BusinessUnitDto _businessUnit, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<BusinessUnit> BusinessUnitService = _dataRepositoryFactory.GetRepository<BusinessUnit>();
            BusinessUnitDto _updatedBusinessUnit = Mapper.Map<BusinessUnitDto>(BusinessUnitService.Update(Mapper.Map<BusinessUnit>(_businessUnit)));

            return _updatedBusinessUnit;
        }

        public BusinessUnitDto UpdateBusinessUnit(BusinessUnitDto _businessUnit, long _businessUnitId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<BusinessUnit> BusinessUnitService = _dataRepositoryFactory.GetRepository<BusinessUnit>();
            BusinessUnitDto _updatedBusinessUnit = Mapper.Map<BusinessUnitDto>(BusinessUnitService.Update(Mapper.Map<BusinessUnit>(_businessUnit), _businessUnitId));

            return _updatedBusinessUnit;
        }

        public BusinessUnitDto GetBusinessUnitByBusinessUnitId(long _businessUnitId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<BusinessUnit> BusinessUnitService = _dataRepositoryFactory.GetRepository<BusinessUnit>();
            BusinessUnitDto _businessUnit = Mapper.Map<BusinessUnitDto>(BusinessUnitService.GetSingle(c => c.BusinessUnitId == _businessUnitId && c.OrganizationId == _organizationId, "StType"));

            return _businessUnit;
        }

        public ICollection<BusinessUnitDto> GetAllBusinessUnits(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<BusinessUnit> BusinessUnitService = _dataRepositoryFactory.GetRepository<BusinessUnit>();
            ICollection<BusinessUnitDto> _allBusinessUnits = Mapper.Map<ICollection<BusinessUnitDto>>(BusinessUnitService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allBusinessUnits;
        }

        public IEnumerable<BusinessUnitDto> GetBusinessUnitList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<BusinessUnit> BusinessUnitService = _dataRepositoryFactory.GetRepository<BusinessUnit>();
            IEnumerable<BusinessUnitDto> _allBusinessUnits = Mapper.Map<IEnumerable<BusinessUnitDto>>(BusinessUnitService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), "StType"));

            return _allBusinessUnits;
        }

        public long GetBusinessUnitCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<BusinessUnit> BusinessUnitService = _dataRepositoryFactory.GetRepository<BusinessUnit>();
            return BusinessUnitService.Count(i=>i.OrganizationId.Equals(_organizationId));
        }

        public IEnumerable<BusinessUnitDto> GetBusinessUnitsByStTypeId(long _stTypeId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<BusinessUnit> BusinessUnitService = _dataRepositoryFactory.GetRepository<BusinessUnit>();
            IEnumerable<BusinessUnitDto> _sTypeBusinessUnits = Mapper.Map<IEnumerable<BusinessUnitDto>>(BusinessUnitService.GetList(c => c.StTypeId == _stTypeId && c.OrganizationId == _organizationId, null, "StType"));

            return _sTypeBusinessUnits;
        }
    }
}
