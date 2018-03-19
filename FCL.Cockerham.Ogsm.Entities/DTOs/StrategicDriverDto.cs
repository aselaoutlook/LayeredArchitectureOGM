using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class StrategicDriverDto
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
        public virtual ICollection<ActionPlanPlainDto> ActionPlans { get; set; }
        public virtual ICollection<CalendarEventPlainDto> CalendarEvents { get; set; }
        public virtual GoalPlainDto Goal { get; set; }
        public virtual GoalCategoryPlainDto GoalCategory { get; set; }
        public virtual UserPlainDto Owner { get; set; }
        public virtual StTypePlainDto StType { get; set; }
        public virtual PillarDto Pillar { get; set; }
        public virtual FiscalYearPlainDto FiscalYear { get; set; }
        public virtual ICollection<StrategicDriverTarget> StrategicDriverTargets { get; set; }
        public virtual ICollection<EmployeeStrategyPlainDto> EmployeeStrategies { get; set; }
    }
}
