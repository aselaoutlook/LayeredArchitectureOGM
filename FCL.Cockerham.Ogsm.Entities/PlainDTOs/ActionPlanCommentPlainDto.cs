using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class ActionPlanCommentPlainDto
    {
        public long ActionPlanCommentId { get; set; }
        public long ActionPlanId { get; set; }
        [Required]
        public string Comment { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ActionPlanDto ActionPlan { get; set; }
    }
}

