using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class AppSettingBaseEntityConfiguration : EntityTypeConfiguration<AppSettingBase>
    {
        public AppSettingBaseEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.AppSettings)
                .WithRequired(e => e.AppSettingBase)
                .WillCascadeOnDelete(false);
        }
    }
}

