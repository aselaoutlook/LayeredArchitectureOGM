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
    [Export(typeof(ICsfService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CsfService : ICsfService
    {
        public CsfDto CreateCsf(CsfDto _csf, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Csf> CsfService = _dataRepositoryFactory.GetRepository<Csf>();            
            CsfDto _createdCsf = Mapper.Map<CsfDto>(CsfService.Add(Mapper.Map<Csf>(_csf)));

            return _createdCsf;
        }

        public CsfDto UpdateCsf(CsfDto _csf, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Csf> CsfService = _dataRepositoryFactory.GetRepository<Csf>();
            CsfDto _updatedCsf = Mapper.Map<CsfDto>(CsfService.Update(Mapper.Map<Csf>(_csf)));

            return _updatedCsf;
        }

        public CsfDto UpdateCsf(CsfDto _csf, long _csfId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Csf> CsfService = _dataRepositoryFactory.GetRepository<Csf>();
            CsfDto _updatedCsf = Mapper.Map<CsfDto>(CsfService.Update(Mapper.Map<Csf>(_csf), _csfId));

            return _updatedCsf;
        }

        public CsfDto GetCsfByCsfId(long _csfId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Csf> CsfService = _dataRepositoryFactory.GetRepository<Csf>();
            CsfDto _csf = Mapper.Map<CsfDto>(CsfService.GetSingle(c => c.CsfId.Equals(_csfId) && c.OrganizationId.Equals(_organizationId), "StType"));

            return _csf;
        }

        public ICollection<CsfDto> GetAllCsfs(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Csf> CsfService = _dataRepositoryFactory.GetRepository<Csf>();
            ICollection<CsfDto> _allCsfs = Mapper.Map<ICollection<CsfDto>>(CsfService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allCsfs;
        }

        public IEnumerable<CsfDto> GetCsfList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Csf> CsfService = _dataRepositoryFactory.GetRepository<Csf>();
            IEnumerable<CsfDto> _allCsfs = Mapper.Map<IEnumerable<CsfDto>>(CsfService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), "StType"));

            return _allCsfs;
        }

        public IEnumerable<CsfDto> GetCsfByStTypeId(long _stTypeId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Csf> CsfService = _dataRepositoryFactory.GetRepository<Csf>();
            IEnumerable<CsfDto> _stTypeCsf = Mapper.Map<IEnumerable<CsfDto>>(CsfService.GetList(c => c.OrganizationId.Equals(_organizationId) && c.StTypeId.Equals(_stTypeId), null, "StType"));

            return _stTypeCsf;
        }

        public long GetCsfCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Csf> CsfService = _dataRepositoryFactory.GetRepository<Csf>();
            return CsfService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
