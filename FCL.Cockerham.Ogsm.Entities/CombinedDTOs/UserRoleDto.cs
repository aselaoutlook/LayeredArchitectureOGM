using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Entities.CombinedDTOs
{
    public class UserRoleDto
    {
        public long Role_Id { get; set; }
        public string RoleName { get; set; }
        public List<RolePermissionDto> Permissions = new List<RolePermissionDto>();
    }
}
