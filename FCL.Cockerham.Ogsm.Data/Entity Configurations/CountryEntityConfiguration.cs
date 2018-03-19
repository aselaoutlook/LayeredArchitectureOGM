using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class CountryEntityConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.Locations)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.States)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);
        }
    }
}

