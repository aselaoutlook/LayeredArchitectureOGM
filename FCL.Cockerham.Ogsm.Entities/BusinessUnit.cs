using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("BusinessUnit")]
    public partial class BusinessUnit : EntityBase, IIdentifiableEntity
    {
        public long BusinessUnitId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        public long? StTypeId { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public bool IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual StType StType { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return BusinessUnitId; }
            set { BusinessUnitId = value; }
        }

        #endregion
    }
}

