using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IActionPlanCommentService
    {
        ActionPlanCommentDto CreateActionPlanComment(ActionPlanCommentDto _actionPlanComment, IUnitOfWork _dataRepositoryFactory);
        ActionPlanCommentDto UpdateActionPlanComment(ActionPlanCommentDto _actionPlanComment, IUnitOfWork _dataRepositoryFactory);
        ActionPlanCommentDto UpdateActionPlanComment(ActionPlanCommentDto _actionPlanComment, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        ActionPlanCommentDto GetActionPlanCommentByActionPlanCommentId(long _actionPlanComment, IUnitOfWork _dataRepositoryFactory);
        ICollection<ActionPlanCommentDto> GetAllActionPlanComments(IUnitOfWork _dataRepositoryFactory);
        IEnumerable<ActionPlanCommentDto> GetActionPlanCommentList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory);
        long GetActionPlanCommentCount(IUnitOfWork _dataRepositoryFactory); 
    }
}