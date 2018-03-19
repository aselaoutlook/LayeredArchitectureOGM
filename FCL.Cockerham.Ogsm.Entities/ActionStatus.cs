using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("ActionStatus")]
    public partial class ActionStatus : EntityBase, IIdentifiableEntity
    {
        public ActionStatus()
        {
            ActionPlans = new HashSet<ActionPlan>();
        }

        [Key]
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

        public virtual ActionOperator ActionOperator { get; set; }

        public virtual ICollection<ActionPlan> ActionPlans { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return ActionStatusId; }
            set { ActionStatusId = value; }
        }

        #endregion
    }
}
