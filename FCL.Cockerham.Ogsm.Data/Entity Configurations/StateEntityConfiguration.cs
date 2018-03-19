using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class StateEntityConfiguration : EntityTypeConfiguration<State>
    {
        public StateEntityConfiguration()
        { 
            this.Ignore(e => e.EntityId);
        }
    }
}
