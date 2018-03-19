using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class RolePlainDto
    {
        public long RoleId { get; set; }
        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }
        [StringLength(1500)]
        public string RoleDescription { get; set; }
        public bool IsSysAdmin { get; set; }
        //public virtual ICollection<PermissionDto> Permissions { get; set; }
        //public virtual ICollection<UserDto> Users { get; set; }
    }
}
