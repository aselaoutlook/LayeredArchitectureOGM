using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class CalendarEventPlainDto
    {
        public long CalendarEventId { get; set; }
        public long? GoalId { get; set; }
        public long? GoalCategoryId { get; set; }
        public long? StrategicDriverId { get; set; }
        public long? ActionPlanId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        [StringLength(300)]
        public string Location { get; set; }
        [StringLength(10)]
        public string BgColor { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual GoalCategoryDto Goal { get; set; }
        public virtual GoalCategoryDto GoalCategory { get; set; }
        public virtual StrategicDriverDto StrategicDriver { get; set; }
        public virtual ActionPlanDto ActionPlan { get; set; }
    }
}

