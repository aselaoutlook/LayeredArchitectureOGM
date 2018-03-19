using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class GoalCategoryRepository : BaseRepository<GoalCategory>, IGoalCategoryRepository
    {
        public GoalCategoryRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}