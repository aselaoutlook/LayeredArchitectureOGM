using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("Location")]
    public partial class Location : EntityBase, IIdentifiableEntity
    {
        public long LocationId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public bool IsGlobal { get; set; }

        public long StateId { get; set; }

        public long CountryId { get; set; }

        public long GlobalRegionId { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Country Country { get; set; }

        public virtual GlobalRegion GlobalRegion { get; set; }

        public virtual State State { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return LocationId; }
            set { LocationId = value; }
        }

        #endregion

    }
}

