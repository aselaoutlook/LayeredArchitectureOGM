﻿using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class DisplayNameEntityConfiguration : EntityTypeConfiguration<DisplayName>
    {
        public DisplayNameEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}
