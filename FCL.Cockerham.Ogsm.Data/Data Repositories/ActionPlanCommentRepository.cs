using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class ActionPlanCommentRepository : BaseRepository<ActionPlanComment>, IActionPlanCommentRepository
    {
        public ActionPlanCommentRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}