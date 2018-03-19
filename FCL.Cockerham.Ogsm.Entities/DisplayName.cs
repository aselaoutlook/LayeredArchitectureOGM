using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("DisplayName")]
    public partial class DisplayName : EntityBase, IIdentifiableEntity
    {
        public long DisplayNameId { get; set; }

        public long OrganizationId { get; set; }

        public long DisplayBaseId { get; set; }

        [Required]
        [StringLength(300)]
        public string DisplayValue { get; set; }

        public virtual DisplayBase DisplayBase { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return DisplayNameId; }
            set { DisplayNameId = value; }
        }

        #endregion
        
    }
}

