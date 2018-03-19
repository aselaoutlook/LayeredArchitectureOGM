using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class LocationEntityConfiguration : EntityTypeConfiguration<Location>
    {
        public LocationEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}