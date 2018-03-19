using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class EmployeeEntityConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.EmployeeStrategies)
                .WithRequired(e => e.EmployeeStrategyEmployee)
                .WillCascadeOnDelete(false);
        }
    }
}
