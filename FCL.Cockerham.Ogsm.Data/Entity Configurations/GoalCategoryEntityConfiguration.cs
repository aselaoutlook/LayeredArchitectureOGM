using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class GoalCategoryEntityConfiguration : EntityTypeConfiguration<GoalCategory>
    {
        public GoalCategoryEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}