using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("ActionOperator")]
    public partial class ActionOperator : EntityBase, IIdentifiableEntity
    {
        public ActionOperator()
        {
            ActionStatuses = new HashSet<ActionStatus>();
        }

        public long ActionOperatorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Operator { get; set; }
        public virtual ICollection<ActionStatus> ActionStatuses { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return ActionOperatorId; }
            set { ActionOperatorId = value; }
        }

        #endregion
    }
}
