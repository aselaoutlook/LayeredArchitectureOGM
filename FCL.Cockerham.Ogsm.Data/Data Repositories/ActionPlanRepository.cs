using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class ActionPlanRepository : BaseRepository<ActionPlan>, IActionPlanRepository
    {
        public ActionPlanRepository(FclDBContext context)
            : base(context)
        {
        } 
    }
}