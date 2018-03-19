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
    [Export(typeof(IScorecardPerspectiveService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScorecardPerspectiveService
    {
        public ScorecardPerspectiveDto CreateScorecardPerspective(ScorecardPerspectiveDto _scorecardPerspective, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ScorecardPerspective> ScorecardPerspectiveService = _dataRepositoryFactory.GetRepository<ScorecardPerspective>();
            ScorecardPerspectiveDto _createdScorecardPerspective = Mapper.Map<ScorecardPerspectiveDto>(ScorecardPerspectiveService.Add(Mapper.Map<ScorecardPerspective>(_scorecardPerspective)));

            return _createdScorecardPerspective;
        }

        public ScorecardPerspectiveDto UpdateScorecardPerspective(ScorecardPerspectiveDto _scorecardPerspective, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ScorecardPerspective> ScorecardPerspectiveService = _dataRepositoryFactory.GetRepository<ScorecardPerspective>();
            ScorecardPerspectiveDto _updatedScorecardPerspective = Mapper.Map<ScorecardPerspectiveDto>(ScorecardPerspectiveService.Update(Mapper.Map<ScorecardPerspective>(_scorecardPerspective)));

            return _updatedScorecardPerspective;
        }

        public ScorecardPerspectiveDto UpdateScorecardPerspective(ScorecardPerspectiveDto _scorecardPerspective, long _scorecardPerspectiveId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ScorecardPerspective> ScorecardPerspectiveService = _dataRepositoryFactory.GetRepository<ScorecardPerspective>();
            ScorecardPerspectiveDto _updatedScorecardPerspective = Mapper.Map<ScorecardPerspectiveDto>(ScorecardPerspectiveService.Update(Mapper.Map<ScorecardPerspective>(_scorecardPerspective), _scorecardPerspectiveId));

            return _updatedScorecardPerspective;
        }

        public ScorecardPerspectiveDto GetScorecardPerspectiveByScorecardPerspectiveId(long _scorecardPerspectiveId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ScorecardPerspective> ScorecardPerspectiveService = _dataRepositoryFactory.GetRepository<ScorecardPerspective>();
            ScorecardPerspectiveDto _scorecardPerspective = Mapper.Map<ScorecardPerspectiveDto>(ScorecardPerspectiveService.GetSingle(i => i.ScorecardPerspectiveId.Equals(_scorecardPerspectiveId) && i.OrganizationId.Equals(_organizationId)));

            return _scorecardPerspective;
        }

        public ICollection<ScorecardPerspectiveDto> GetAllScorecardPerspectives(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ScorecardPerspective> ScorecardPerspectiveService = _dataRepositoryFactory.GetRepository<ScorecardPerspective>();
            ICollection<ScorecardPerspectiveDto> _allScorecardPerspectives = Mapper.Map<ICollection<ScorecardPerspectiveDto>>(ScorecardPerspectiveService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allScorecardPerspectives;
        }

        public IEnumerable<ScorecardPerspectiveDto> GetScorecardPerspectiveList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ScorecardPerspective> ScorecardPerspectiveService = _dataRepositoryFactory.GetRepository<ScorecardPerspective>();
            IEnumerable<ScorecardPerspectiveDto> _allScorecardPerspectives = Mapper.Map<IEnumerable<ScorecardPerspectiveDto>>(ScorecardPerspectiveService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), null));

            return _allScorecardPerspectives;
        }

        public long GetScorecardPerspectiveCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ScorecardPerspective> ScorecardPerspectiveService = _dataRepositoryFactory.GetRepository<ScorecardPerspective>();
            return ScorecardPerspectiveService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}