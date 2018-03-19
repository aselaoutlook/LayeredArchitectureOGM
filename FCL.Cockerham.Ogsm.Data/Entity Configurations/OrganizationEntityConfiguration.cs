using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class OrganizationEntityConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}
