using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class GlobalRegionEntityConfiguration : EntityTypeConfiguration<GlobalRegion>
    {
        public GlobalRegionEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.Countries)
                .WithRequired(e => e.GlobalRegion)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Locations)
                .WithRequired(e => e.GlobalRegion)
                .WillCascadeOnDelete(false);
        }
    }
}