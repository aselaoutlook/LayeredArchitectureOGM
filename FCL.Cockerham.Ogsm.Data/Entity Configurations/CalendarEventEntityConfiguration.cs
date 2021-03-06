﻿using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class CalendarEventEntityConfiguration : EntityTypeConfiguration<CalendarEvent>
    {
        public CalendarEventEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}
