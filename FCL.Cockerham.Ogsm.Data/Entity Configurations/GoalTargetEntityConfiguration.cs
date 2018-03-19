using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class GoalTargetEntityConfiguration : EntityTypeConfiguration<GoalTarget>
    {
        public GoalTargetEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}