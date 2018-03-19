using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("Role")]
    public partial class Role : EntityBase, IIdentifiableEntity
    {
        public Role()
        {
            Permissions = new HashSet<Permission>();
            Users = new HashSet<User>();
        }

        public long RoleId { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }

        [StringLength(1500)]
        public string RoleDescription { get; set; }

        public bool IsSysAdmin { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public virtual ICollection<User> Users { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return RoleId; }
            set { RoleId = value; }
        }

        #endregion
    }
}
