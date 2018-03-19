using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class RoleDto
    {
        public long RoleId { get; set; }
        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }
        [StringLength(1500)]
        public string RoleDescription { get; set; }
        public bool IsSysAdmin { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
