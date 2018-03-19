using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class GoalEntityConfiguration : EntityTypeConfiguration<Goal>
    {
        public GoalEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.GoalTargets)
                .WithRequired(e => e.Goal)
                .WillCascadeOnDelete(false);
        }
    }
}
