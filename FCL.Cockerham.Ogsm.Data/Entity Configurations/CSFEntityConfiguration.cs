using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class CSFEntityConfiguration : EntityTypeConfiguration<Csf>
    {
        public CSFEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}