using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("StrategicDriverTarget")]
    public partial class StrategicDriverTarget : EntityBase, IIdentifiableEntity
    {
        public long StrategicDriverTargetId { get; set; }

        public long StrategicDriverId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(10)]
        public string QuaterName { get; set; }

        public decimal QuaterValue { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual StrategicDriver StrategicDriver { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return StrategicDriverTargetId; }
            set { StrategicDriverTargetId = value; }
        }

        #endregion
    }
}
