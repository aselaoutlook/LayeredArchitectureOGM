using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class ActionPlanCommentDto
    {
        public long ActionPlanCommentId { get; set; }
        public long ActionPlanId { get; set; }
        [Required]
        public string Comment { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ActionPlanPlainDto ActionPlan { get; set; }
    }
}

