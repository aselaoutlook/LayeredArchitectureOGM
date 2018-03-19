using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("StrategicDriver")]
    public partial class StrategicDriver : EntityBase, IIdentifiableEntity
    {
        public StrategicDriver()
        {
            ActionPlans = new HashSet<ActionPlan>();
            CalendarEvents = new HashSet<CalendarEvent>();
            StrategicDriverTargets = new HashSet<StrategicDriverTarget>();
            EmployeeStrategies = new HashSet<EmployeeStrategy>();
        }

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

        public virtual ICollection<ActionPlan> ActionPlans { get; set; }

        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }

        public virtual Goal Goal { get; set; }

        public virtual Pillar Pillar { get; set; }

        public virtual GoalCategory GoalCategory { get; set; }

        public virtual User Owner { get; set; }

        public virtual StType StType { get; set; }

        public virtual FiscalYear FiscalYear { get; set; }

        public virtual ICollection<StrategicDriverTarget> StrategicDriverTargets { get; set; }

        public virtual ICollection<EmployeeStrategy> EmployeeStrategies { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return StrategicDriverId; }
            set { StrategicDriverId = value; }
        }

        #endregion

    }
}
