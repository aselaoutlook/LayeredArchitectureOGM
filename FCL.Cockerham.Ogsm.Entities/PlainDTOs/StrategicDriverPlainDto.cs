using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class StrategicDriverPlainDto
    {

        public long StrategicDriverId { get; set; }
        public long? StTypeId { get; set; }
        public long? GoalId { get; set; }
        public long? PillarId { get; set; }
        public long? GoalCategoryId { get; set; }
        public long? FiscalYearId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(1500)]
        public string Name { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(300)]
        public string Metric { get; set; }
        public decimal? MetricTarget { get; set; }
        public bool IsMetricDefault { get; set; }
        public bool IsIndexed { get; set; }
        public decimal? WeightActionPlan { get; set; }
        public decimal? WeightMetric { get; set; }
        public long? OwnerId { get; set; }
        public int? SequenceNumber { get; set; }
        public bool? UseMultipleMetrics { get; set; }
        public bool? IsCascade { get; set; }
        public bool? IsBestPractice { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        //public virtual ICollection<ActionPlan> ActionPlans { get; set; }
        //public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
        public virtual GoalDto Goal { get; set; }
        public virtual GoalCategoryDto GoalCategory { get; set; }
        public virtual UserDto Owner { get; set; }
        public virtual StTypeDto StType { get; set; }
        public virtual PillarDto Pillar { get; set; }
        public virtual FiscalYearDto FiscalYear { get; set; }
        //public virtual ICollection<StrategicDriverTarget> StrategicDriverTargets { get; set; }
        //public virtual ICollection<EmployeeStrategy> EmployeeStrategies { get; set; }
    }
}
