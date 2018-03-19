using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class EmployeeStrategyEntityConfiguration : EntityTypeConfiguration<EmployeeStrategy>
    {
        public EmployeeStrategyEntityConfiguration()
        { 
            this.Ignore(e => e.EntityId);

            this.Property(e => e.Notes)
                .IsUnicode(false);


        }
    }
}
