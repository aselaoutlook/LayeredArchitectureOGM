using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class StrategicDriverEntityConfiguration : EntityTypeConfiguration<StrategicDriver>
    {
        public StrategicDriverEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.StrategicDriverTargets)
                .WithRequired(e => e.StrategicDriver)
                .WillCascadeOnDelete(false);
        }
    }
}