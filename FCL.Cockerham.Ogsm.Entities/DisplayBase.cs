using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("DisplayBase")]
    public partial class DisplayBase : EntityBase, IIdentifiableEntity
    {
        public DisplayBase()
        {
            DisplayNames = new HashSet<DisplayName>();
        }

        public long DisplayBaseId { get; set; }

        [Required]
        [StringLength(300)]
        public string DisplayValue { get; set; }

        public virtual ICollection<DisplayName> DisplayNames { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return DisplayBaseId; }
            set { DisplayBaseId = value; }
        }

        #endregion
    }
}
