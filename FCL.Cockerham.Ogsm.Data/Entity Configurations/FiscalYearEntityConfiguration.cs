using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class FiscalYearEntityConfiguration : EntityTypeConfiguration<FiscalYear>
    {
        public FiscalYearEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}
