using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IScorecardPerspectiveService
    {
        ScorecardPerspectiveDto CreateScorecardPerspective(ScorecardPerspectiveDto _scorecardPerspective, IUnitOfWork _dataRepositoryFactory);
        ScorecardPerspectiveDto UpdateScorecardPerspective(ScorecardPerspectiveDto _scorecardPerspective, IUnitOfWork _dataRepositoryFactory);
        ScorecardPerspectiveDto UpdateScorecardPerspective(ScorecardPerspectiveDto _scorecardPerspective, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        ScorecardPerspectiveDto GetScorecardPerspectiveByScorecardPerspectiveId(long _scorecardPerspectiveId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<ScorecardPerspectiveDto> GetAllScorecardPerspectives(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<ScorecardPerspectiveDto> GetScorecardPerspectiveList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetScorecardPerspectiveCount(long _organizationId, IUnitOfWork _dataRepositoryFactory); 
    }
}