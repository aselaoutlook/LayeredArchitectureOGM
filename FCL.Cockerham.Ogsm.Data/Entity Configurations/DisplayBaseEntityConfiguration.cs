using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class DisplayBaseEntityConfiguration : EntityTypeConfiguration<DisplayBase>
    {
        public DisplayBaseEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.DisplayNames)
                .WithRequired(e => e.DisplayBase)
                .WillCascadeOnDelete(false);
        }
    }
}
