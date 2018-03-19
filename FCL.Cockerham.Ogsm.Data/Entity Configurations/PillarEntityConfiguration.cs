using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class PillarEntityConfiguration : EntityTypeConfiguration<Pillar>
    {
        public PillarEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}