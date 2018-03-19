using FCL.Cockerham.Ogsm.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class ActionStatusEntityConfiguration : EntityTypeConfiguration<ActionStatus>
    {
        public ActionStatusEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.Property(e => e.Status)
                .IsUnicode(false);

            this.Property(e => e.colorcode)
                .IsUnicode(false);

            this.Property(e => e.ChartStatus)
                .IsUnicode(false);
        }
    }
}
