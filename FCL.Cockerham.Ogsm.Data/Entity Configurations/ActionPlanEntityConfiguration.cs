﻿using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class ActionPlanEntityConfiguration : EntityTypeConfiguration<ActionPlan>
    {
        public ActionPlanEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.ActionPlanComments)
                .WithRequired(e => e.ActionPlan)
                .WillCascadeOnDelete(false);
        }
    }
}