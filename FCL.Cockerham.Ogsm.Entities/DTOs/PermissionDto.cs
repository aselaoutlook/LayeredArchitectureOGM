using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class PermissionDto
    {
        public long PermissionId { get; set; }
        [Required]
        [StringLength(1500)]
        public string PermissionDescription { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
