using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("State")]
    public partial class State : EntityBase, IIdentifiableEntity
    {
        public State()
        {
            Locations = new HashSet<Location>();
        }

        public long StateId { get; set; }

        public long CountryId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string StateName { get; set; }

        [StringLength(10)]
        public string StateCode { get; set; }

        public virtual Country Country { get; set; }


        public virtual ICollection<Location> Locations { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return StateId; }
            set { StateId = value; }
        }

        #endregion
    }
}
     
