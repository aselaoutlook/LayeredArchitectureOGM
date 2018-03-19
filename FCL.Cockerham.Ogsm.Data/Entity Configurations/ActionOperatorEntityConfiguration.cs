using FCL.Cockerham.Ogsm.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class ActionOperatorEntityConfiguration : EntityTypeConfiguration<ActionOperator>
    {
        public ActionOperatorEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.Property(e => e.Operator)
                .IsUnicode(false);

            this.HasMany(e => e.ActionStatuses)
                .WithOptional(e => e.ActionOperator)
                .HasForeignKey(e => e.Operator);
        }

    }
}
