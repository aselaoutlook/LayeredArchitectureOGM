using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class StTypeEntityConfiguration : EntityTypeConfiguration<StType>
    {
        public StTypeEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}

