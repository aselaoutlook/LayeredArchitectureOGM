using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("ActionPlanComment")]
    public partial class ActionPlanComment : EntityBase, IIdentifiableEntity
    {
        public long ActionPlanCommentId { get; set; }

        public long ActionPlanId { get; set; }

        [Required]
        public string Comment { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ActionPlan ActionPlan { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return ActionPlanCommentId; }
            set { ActionPlanCommentId = value; }
        }

        #endregion
    }
}

