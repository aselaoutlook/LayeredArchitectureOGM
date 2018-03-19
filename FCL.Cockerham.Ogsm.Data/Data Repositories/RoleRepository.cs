#region Header
///-------------------------------------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Data_Repositories
///MODULE        :         
///SUB MODULE    :    
///Class         : RoleRepository
///AUTHOR        : Asela Chamara      
///CREATED       : 05/10/2015
///LAST EDITED   : 11/28/2015
///DESCRIPTION   : Purpose is to provide a repository class to override existing BaseRepository methods or create specific 
///              : methods to save/ mofyfy/ retrive data related to FCL.Cockerham.Ogsm.Entities.Role entity   
///MODIFICATION HISTORY:  V2
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using System.Linq;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(FclDBContext context)
            : base(context)
        {
        }

        public Role AddAllPermissionToRole(Role role)
        {
            var permissionquery = (from e in context.Permissions
                                   select e);

            List<Permission> _permissions = permissionquery.ToList();

            foreach (Permission _permission in _permissions)
            {
                if (!role.Permissions.Contains(_permission))
                {
                    role.Permissions.Add(_permission);
                }
            }

            context.SaveChanges();
            return role;
        }
    }
}
