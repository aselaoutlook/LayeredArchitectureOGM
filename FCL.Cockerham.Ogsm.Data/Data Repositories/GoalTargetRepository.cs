using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class GoalTargetRepository : BaseRepository<GoalTarget>, IGoalTargetRepository
    {
        public GoalTargetRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}