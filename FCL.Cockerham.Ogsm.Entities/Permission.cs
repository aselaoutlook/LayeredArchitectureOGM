using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("Permission")]
    public class Permission : EntityBase, IIdentifiableEntity
    {
        public Permission()
        {
            Roles = new HashSet<Role>();
        }

        public long PermissionId { get; set; }

        [Required]
        [StringLength(1500)]
        public string PermissionDescription { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return PermissionId; }
            set { PermissionId = value; }
        }

        #endregion
    }
}
