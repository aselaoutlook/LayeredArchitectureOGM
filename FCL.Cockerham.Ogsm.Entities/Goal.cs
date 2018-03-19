using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("Goal")]
    public partial class Goal : EntityBase, IIdentifiableEntity
    {
        public Goal()
        {
            ActionPlans = new HashSet<ActionPlan>();
            CalendarEvents = new HashSet<CalendarEvent>();
            GoalTargets = new HashSet<GoalTarget>();
            StrategicDrivers = new HashSet<StrategicDriver>();
        }

        public long GoalId { get; set; }

        public long? PillarId { get; set; }

        public long? GoalCategoryId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(1500)]
        public string Name { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        [StringLength(1500)]
        public string AltDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long? PrimaryOwnerId { get; set; }

        public long? SecondryOwnerId { get; set; }

        [StringLength(1500)]
        public string RationaleNotes { get; set; }

        public decimal Target { get; set; }

        public decimal TargetDesc { get; set; }

        public int GoalYears { get; set; }

        public int? NoOfYears { get; set; }

        public int? SequenceNumber { get; set; }

        public DateTime? BaselineDate { get; set; }

        public int? BaselineNo { get; set; }

        public bool IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<ActionPlan> ActionPlans { get; set; }

        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }

        public virtual User PrimaryOwner { get; set; }

        public virtual User SecondryOwner { get; set; }

        public virtual GoalCategory GoalCategory { get; set; }

        public virtual Pillar Pillar { get; set; }

        public virtual ICollection<GoalTarget> GoalTargets { get; set; }

        public virtual ICollection<StrategicDriver> StrategicDrivers { get; set; }


        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return GoalId; }
            set { GoalId = value; }
        }

        #endregion

    }
}
