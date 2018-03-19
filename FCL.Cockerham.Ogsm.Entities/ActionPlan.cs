using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("ActionPlan")]
    public partial class ActionPlan : EntityBase, IIdentifiableEntity
    {

        public ActionPlan()
        {
            ActionPlanComments = new List<ActionPlanComment>();
        }

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

        public virtual Goal Goal { get; set; }

        public virtual Pillar Pillar { get; set; }

        public virtual StrategicDriver StrategicDriver { get; set; }

        public virtual User ActionPlanOwner { get; set; }

        public virtual List<ActionPlanComment> ActionPlanComments { get; set; }

        public virtual List<CalendarEvent> CalendarEvents { get; set; }

        public virtual ActionStatus ActionStatus { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return ActionPlanId; }
            set { ActionPlanId = value; }
        }

        #endregion

    }
}


