using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("Country")]
    public partial class Country : EntityBase, IIdentifiableEntity
    {
        public Country()
        {
            Locations = new HashSet<Location>();
            States = new HashSet<State>();
        }

        public long CountryId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public long GlobalRegionId { get; set; }

        public virtual GlobalRegion GlobalRegion { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<State> States { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return CountryId; }
            set { CountryId = value; }
        }

        #endregion
    }
}


