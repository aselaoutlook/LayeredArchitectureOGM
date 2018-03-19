using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("GlobalRegion")]
    public partial class GlobalRegion : EntityBase, IIdentifiableEntity
    {        
        public GlobalRegion()
        {
            Countries = new HashSet<Country>();
            Locations = new HashSet<Location>();
        }

        public long GlobalRegionId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return GlobalRegionId; }
            set { GlobalRegionId = value; }
        }

        #endregion

    }
}
