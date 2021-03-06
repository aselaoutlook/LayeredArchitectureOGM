﻿using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class AppSettingEntityConfiguration : EntityTypeConfiguration<AppSetting>
    {
        public AppSettingEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}
