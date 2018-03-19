using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("CalendarEvent")]
    public partial class CalendarEvent : EntityBase, IIdentifiableEntity
    {

        public long CalendarEventId { get; set; }

        public long? GoalId { get; set; }

        public long? PillarId { get; set; }

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

        public virtual Goal Goal { get; set; }

        public virtual Pillar Pillar { get; set; }

        public virtual GoalCategory GoalCategory { get; set; }

        public virtual StrategicDriver StrategicDriver { get; set; }

        public virtual ActionPlan ActionPlan { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return CalendarEventId; }
            set { CalendarEventId = value; }
        }

        #endregion

    }
}

