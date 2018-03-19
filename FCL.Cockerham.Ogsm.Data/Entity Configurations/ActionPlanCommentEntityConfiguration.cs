using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class ActionPlanCommentEntityConfiguration : EntityTypeConfiguration<ActionPlanComment>
    {
        public ActionPlanCommentEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
        }
    }
}