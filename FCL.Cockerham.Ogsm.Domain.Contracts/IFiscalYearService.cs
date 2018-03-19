using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IFiscalYearService
    {
        FiscalYearDto CreateFiscalYear(FiscalYearDto _fiscalYear, IUnitOfWork _dataRepositoryFactory);
        FiscalYearDto UpdateFiscalYear(FiscalYearDto _fiscalYear, IUnitOfWork _dataRepositoryFactory);
        FiscalYearDto UpdateFiscalYear(FiscalYearDto _fiscalYear, long _fiscalYearId, IUnitOfWork _dataRepositoryFactory);
        FiscalYearDto GetFiscalYearByFiscalYearId(long _fiscalYearId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<FiscalYearDto> GetAllFiscalYears(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<FiscalYearDto> GetFiscalYearList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetFiscalYearCount(long _organizationId, IUnitOfWork _dataRepositoryFactory);
    }
}
