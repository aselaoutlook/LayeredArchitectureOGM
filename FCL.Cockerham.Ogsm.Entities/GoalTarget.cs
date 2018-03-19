using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("GoalTarget")]
    public partial class GoalTarget : EntityBase, IIdentifiableEntity
    {
        public long GoalTargetId { get; set; }

        public long GoalId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(10)]
        public string YearName { get; set; }

        public decimal YearValue { get; set; }

        public decimal Results { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Goal Goal { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return GoalTargetId; }
            set { GoalTargetId = value; }
        }

        #endregion
    }
}

