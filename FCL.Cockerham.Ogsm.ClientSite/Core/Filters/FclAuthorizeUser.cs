using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using FCL.Cockerham.Ogsm.Entities.CombinedDTOs;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Filters
{
    public class FclAuthorizeUser
    {

        public long UserId { get; set; }
        public bool IsSysAdmin { get; set; }
        public string Username { get; set; }
        private List<UserRoleDto> _roles = new List<UserRoleDto>();

        public FclAuthorizeUser(string username)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = Bootstrapper.MefLoader.Init(catalog.Catalogs);
            DataRepositoryFactory = container.GetExportedValue<IUnitOfWork>();
            UserService = DataRepositoryFactory.GetUserRepository();
            this.Username = username;
            this.IsSysAdmin = false;
            GetDatabaseUserRolesPermissions();
        }

        IUnitOfWork DataRepositoryFactory { get; set; }
        IUserRepository UserService { get; set; }

        private void GetDatabaseUserRolesPermissions()
        {
            User user = UserService.GetSingle(i => i.UserName.Equals(this.Username), "Roles.Permissions");
            if (user != null)
            {
                this.UserId = user.UserId;
                foreach (Role role in user.Roles)
                {
                    UserRoleDto userRole = new UserRoleDto { Role_Id = role.RoleId, RoleName = role.RoleName };
                    foreach (Permission permission in role.Permissions)
                    {
                        userRole.Permissions.Add(new RolePermissionDto { Permission_Id = permission.PermissionId, PermissionDescription = permission.PermissionDescription });
                    }
                    this._roles.Add(userRole);

                    if (!this.IsSysAdmin)
                        this.IsSysAdmin = role.IsSysAdmin;
                }
            }
        }

        public bool HasPermission(string requiredPermission)
        {
            bool bFound = false;
            foreach (UserRoleDto role in this._roles)
            {
                bFound = (role.Permissions.Where(p => p.PermissionDescription.ToLower() == requiredPermission.ToLower()).ToList().Count > 0);
                if (bFound)
                    break;
            }
            return bFound;
        }

        public bool HasRole(string role)
        {
            return (_roles.Where(p => p.RoleName == role).ToList().Count > 0);
        }

        public bool HasRoles(string roles)
        {
            bool bFound = false;
            string[] _roles = roles.ToLower().Split(';');
            foreach (UserRoleDto role in this._roles)
            {
                try
                {
                    bFound = _roles.Contains(role.RoleName.ToLower());
                    if (bFound)
                        return bFound;
                }
                catch (Exception)
                {
                }
            }
            return bFound;
        }
    }
}