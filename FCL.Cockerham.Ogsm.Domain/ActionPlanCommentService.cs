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
    [Export(typeof(IActionPlanCommentService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActionPlanCommentService : IActionPlanCommentService
    {
        public ActionPlanCommentDto CreateActionPlanComment(ActionPlanCommentDto _actionPlanComment, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlanComment> ActionPlanCommentService = _dataRepositoryFactory.GetRepository<ActionPlanComment>();
            ActionPlanCommentDto _createdActionPlanComment = Mapper.Map<ActionPlanCommentDto>(ActionPlanCommentService.Add(Mapper.Map<ActionPlanComment>(_actionPlanComment)));

            return _createdActionPlanComment;
        }

        public ActionPlanCommentDto UpdateActionPlanComment(ActionPlanCommentDto _actionPlanComment, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlanComment> ActionPlanCommentService = _dataRepositoryFactory.GetRepository<ActionPlanComment>();
            ActionPlanCommentDto _updatedActionPlanComment = Mapper.Map<ActionPlanCommentDto>(ActionPlanCommentService.Update(Mapper.Map<ActionPlanComment>(_actionPlanComment)));

            return _updatedActionPlanComment;
        }

        public ActionPlanCommentDto UpdateActionPlanComment(ActionPlanCommentDto _actionPlanComment, long _actionPlanCommentId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlanComment> ActionPlanCommentService = _dataRepositoryFactory.GetRepository<ActionPlanComment>();
            ActionPlanCommentDto _updatedActionPlanComment = Mapper.Map<ActionPlanCommentDto>(ActionPlanCommentService.Update(Mapper.Map<ActionPlanComment>(_actionPlanComment), _actionPlanCommentId));

            return _updatedActionPlanComment;
        }

        public ActionPlanCommentDto GetActionPlanCommentByActionPlanCommentId(long _actionPlanCommentId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlanComment> ActionPlanCommentService = _dataRepositoryFactory.GetRepository<ActionPlanComment>();
            ActionPlanCommentDto _actionPlanComment = Mapper.Map<ActionPlanCommentDto>(ActionPlanCommentService.GetSingle(_actionPlanCommentId));

            return _actionPlanComment;
        }

        public ICollection<ActionPlanCommentDto> GetAllActionPlanComments(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlanComment> ActionPlanCommentService = _dataRepositoryFactory.GetRepository<ActionPlanComment>();
            ICollection<ActionPlanCommentDto> _allActionPlanComments = Mapper.Map<ICollection<ActionPlanCommentDto>>(ActionPlanCommentService.GetAll());

            return _allActionPlanComments;
        }

        public IEnumerable<ActionPlanCommentDto> GetActionPlanCommentList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlanComment> ActionPlanCommentService = _dataRepositoryFactory.GetRepository<ActionPlanComment>();
            IEnumerable<ActionPlanCommentDto> _allActionPlanComments = Mapper.Map<IEnumerable<ActionPlanCommentDto>>(ActionPlanCommentService.GetPagedList(pageNo, pageSize, null, q => q.OrderBy(s => s.ActionPlanCommentId), null));

            return _allActionPlanComments;
        }

        public long GetActionPlanCommentCount(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<ActionPlanComment> ActionPlanCommentService = _dataRepositoryFactory.GetRepository<ActionPlanComment>();
            return ActionPlanCommentService.Count();
        }
    }
}