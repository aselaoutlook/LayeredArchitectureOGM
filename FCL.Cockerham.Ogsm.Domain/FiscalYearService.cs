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
    [Export(typeof(IFiscalYearService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FiscalYearService : IFiscalYearService
    {
        public FiscalYearDto CreateFiscalYear(FiscalYearDto _fiscalYear, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<FiscalYear> FiscalYearService = _dataRepositoryFactory.GetRepository<FiscalYear>();
            FiscalYearDto _createdFiscalYear = Mapper.Map<FiscalYearDto>(FiscalYearService.Add(Mapper.Map<FiscalYear>(_fiscalYear)));

            return _createdFiscalYear;
        }

        public FiscalYearDto UpdateFiscalYear(FiscalYearDto _fiscalYear, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<FiscalYear> FiscalYearService = _dataRepositoryFactory.GetRepository<FiscalYear>();
            FiscalYearDto _updatedFiscalYear = Mapper.Map<FiscalYearDto>(FiscalYearService.Update(Mapper.Map<FiscalYear>(_fiscalYear)));

            return _updatedFiscalYear;
        }

        public FiscalYearDto UpdateFiscalYear(FiscalYearDto _fiscalYear, long _fiscalYearId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<FiscalYear> FiscalYearService = _dataRepositoryFactory.GetRepository<FiscalYear>();
            FiscalYearDto _updatedFiscalYear = Mapper.Map<FiscalYearDto>(FiscalYearService.Update(Mapper.Map<FiscalYear>(_fiscalYear), _fiscalYearId));

            return _updatedFiscalYear;
        }

        public FiscalYearDto GetFiscalYearByFiscalYearId(long _fiscalYearId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<FiscalYear> FiscalYearService = _dataRepositoryFactory.GetRepository<FiscalYear>();
            FiscalYearDto _fiscalYear = Mapper.Map<FiscalYearDto>(FiscalYearService.GetSingle(i => i.FiscalYearId.Equals(_fiscalYearId) && i.OrganizationId.Equals(_organizationId)));

            return _fiscalYear;
        }

        public ICollection<FiscalYearDto> GetAllFiscalYears(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<FiscalYear> FiscalYearService = _dataRepositoryFactory.GetRepository<FiscalYear>();
            ICollection<FiscalYearDto> _allFiscalYears = Mapper.Map<ICollection<FiscalYearDto>>(FiscalYearService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allFiscalYears;
        }

        public IEnumerable<FiscalYearDto> GetFiscalYearList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<FiscalYear> FiscalYearService = _dataRepositoryFactory.GetRepository<FiscalYear>();
            IEnumerable<FiscalYearDto> _allFiscalYears = Mapper.Map<IEnumerable<FiscalYearDto>>(FiscalYearService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.FiscalYearId), null));

            return _allFiscalYears;
        }

        public long GetFiscalYearCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<FiscalYear> FiscalYearService = _dataRepositoryFactory.GetRepository<FiscalYear>();
            return FiscalYearService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
