using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class BusinessUnitEntityConfiguration : EntityTypeConfiguration<BusinessUnit>
    {
        public BusinessUnitEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(e => e.Description)
                    .HasMaxLength(1500);
        }
    }
}