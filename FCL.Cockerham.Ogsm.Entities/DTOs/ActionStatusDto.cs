using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class ActionStatusDto
    {
        public long ActionStatusId { get; set; }

        [Required]
        [StringLength(200)]
        public string Status { get; set; }

        public int Factor { get; set; }

        [StringLength(7)]
        public string colorcode { get; set; }

        public long? Operator { get; set; }

        public decimal? RangeStart { get; set; }

        public decimal? RangeEnd { get; set; }

        public bool IsGlobal { get; set; }

        [Required]
        [StringLength(200)]
        public string ChartStatus { get; set; }

        public bool? IsApproveStatus { get; set; }

        public virtual ActionOperatorPlainDto ActionOperator { get; set; }

        public virtual ICollection<ActionPlanPlainDto> ActionPlans { get; set; }
    }
}
