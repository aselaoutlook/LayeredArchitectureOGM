using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class GoalRepository : BaseRepository<Goal>, IGoalRepository
    {
        public GoalRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}