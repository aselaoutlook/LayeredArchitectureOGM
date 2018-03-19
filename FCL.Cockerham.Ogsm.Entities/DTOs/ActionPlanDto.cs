using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class ActionPlanDto
    {
        public long ActionPlanId { get; set; }

        public long? GoalId { get; set; }

        public long? PillarId { get; set; }

        public long? StrategicDriverId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(1500)]
        public string Name { get; set; }

        public long? ActionPlanOwnerId { get; set; }

        public bool IsEvent { get; set; }

        public bool IsCalendarEvent { get; set; }

        public DateTime DueDate { get; set; }

        public decimal? PlannedCost { get; set; }

        public decimal? ActualCost { get; set; }

        public decimal? Impact { get; set; }

        public long? ActionStatusId { get; set; }

        public int? SequenceNumber { get; set; }

        public bool IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual GoalPlainDto Goal { get; set; }

        public virtual PillarPlainDto Pillar { get; set; }

        public virtual StrategicDriverPlainDto StrategicDriver { get; set; }

        public virtual UserPlainDto ActionPlanOwner { get; set; }

        public virtual List<ActionPlanCommentPlainDto> ActionPlanComments { get; set; }

        public virtual List<CalendarEventPlainDto> CalendarEvents { get; set; }

        public virtual ActionStatusPlainDto ActionStatus { get; set; }
    }
}


