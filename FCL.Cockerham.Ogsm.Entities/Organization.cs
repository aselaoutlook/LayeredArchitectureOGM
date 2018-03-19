using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    public partial class Organization : EntityBase, IIdentifiableEntity
    {
        public Organization()
        {
            
        }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string AddressOne { get; set; }

        [StringLength(100)]
        public string AddressTwo { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Logo { get; set; }

        public bool IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return OrganizationId; }
            set { OrganizationId = value; }
        }

        #endregion
    }

}



