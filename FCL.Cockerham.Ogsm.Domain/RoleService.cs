using AutoMapper;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.CombinedDTOs;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IRoleService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RoleService : IRoleService
    {
        public RoleDto CreateRole(RoleDto _role, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();
            RoleDto _createdRole = Mapper.Map<RoleDto>(RoleRepo.Add(Mapper.Map<Role>(_role)));
            return _createdRole;
        }

        public RoleDto GetRoleByRoleId(long _roleId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();
            RoleDto _role = Mapper.Map<RoleDto>(RoleRepo.GetSingle(Mapper.Map<Role>(_roleId)));

            return _role;
        }

        public ICollection<RoleDto> GetAllRoles(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();
            ICollection<RoleDto> _allRoles = Mapper.Map<ICollection<RoleDto>>(RoleRepo.GetAll());

            return _allRoles;
        }

        public RoleDto GetRoleWithPermissionByRoleId(long id, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();
            RoleDto _role = Mapper.Map<RoleDto>(RoleRepo.GetSingle(i => i.RoleId.Equals(id), "Permissions"));

            return _role;
        }

        public RoleDto GetRoleByRoleName(string roleName, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();
            RoleDto _role = Mapper.Map<RoleDto>(RoleRepo.GetSingle(i => i.RoleName.Equals(roleName), "Users"));

            return _role;
        }        

        public RoleDto GetRoleWithDifinedNavigationByRoleId(long id, string navigationProperties, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();
            RoleDto _role = Mapper.Map<RoleDto>(RoleRepo.GetSingle(i => i.RoleId.Equals(id), navigationProperties));

            return _role;
        }

        public RoleDto UpdateRole(RoleDto _role, IUnitOfWork _dataRepositoryFactory)
        {
            IRoleRepository RoleService = _dataRepositoryFactory.GetRoleRepository();
            RoleDto _updatedRole = Mapper.Map<RoleDto>(RoleService.Update(Mapper.Map<Role>(_role)));

            return _updatedRole;
        }

        public RoleDto UpdateRole(RoleDto _role, long _roleId, IUnitOfWork _dataRepositoryFactory)
        {
            IRoleRepository RoleService = _dataRepositoryFactory.GetRoleRepository();
            RoleDto _updatedRole = Mapper.Map<RoleDto>(RoleService.Update(Mapper.Map<Role>(_role), _roleId));

            return _updatedRole;
        }

        public RoleDto GetRoleWithUserByRoleId(long _roleId, IUnitOfWork _dataRepositoryFactory)
        {
            IRoleRepository RoleService = _dataRepositoryFactory.GetRoleRepository();
            RoleDto _role = Mapper.Map<RoleDto>(RoleService.GetSingle(i => i.RoleId.Equals(_roleId), "Users"));

            return _role;
        }

        public RoleDto AddRoleUser(long roleId, long userId, IUserService _userDomainService, IUnitOfWork _dataRepositoryFactory)
        {
            RoleDto role = this.GetRoleWithUserByRoleId(roleId, _dataRepositoryFactory);
            User user = Mapper.Map<User>(_userDomainService.GetUserByUserId(userId, _dataRepositoryFactory));

            if (!role.Users.Contains(user))
            {
                role.Users.Add(user);
                this.UpdateRole(role, role.RoleId, _dataRepositoryFactory);
            }

            return this.GetRoleWithUserByRoleId(roleId, _dataRepositoryFactory);
        }

        public bool DeleteRole(long roleId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();
            RoleDto role = this.GetRoleWithDifinedNavigationByRoleId(roleId, "Users, Permissions", _dataRepositoryFactory);

            if (role != null)
            {
                role.Users.Clear();
                role.Permissions.Clear();
                RoleRepo.Delete(role);
                return true;
            }
            else
            {
                return false;
            }
        }

        public RoleDto DeleteRoleUser(long roleId, long userId, IUserService _userDomainService, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserRepo = _dataRepositoryFactory.GetRepository<User>();
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();

            RoleDto role = this.GetRoleWithUserByRoleId(roleId, _dataRepositoryFactory);
            User user = Mapper.Map<User>(_userDomainService.GetUserByUserId(userId, _dataRepositoryFactory));

            if (role.Users.Where(u => u.UserId == userId).Count() > 0)
            {
                role.Users.Remove(user);
                this.UpdateRole(role, role.RoleId, _dataRepositoryFactory);
            }

            return this.GetRoleWithUserByRoleId(roleId, _dataRepositoryFactory);
        }

        public RoleDto AddRole2Permission(long roleId, long permissionId, IPermissionService _permissionDomainService, IUnitOfWork _dataRepositoryFactory)
        {

            RoleDto role = this.GetRoleWithDifinedNavigationByRoleId(roleId, "Permissions", _dataRepositoryFactory);
            Permission permission = Mapper.Map<Permission>(_permissionDomainService.GetPermissionByPermissionId(permissionId, _dataRepositoryFactory));

            if (!role.Permissions.Contains(permission))
            {
                role.Permissions.Add(permission);
                this.UpdateRole(role, role.RoleId, _dataRepositoryFactory);
            }

            return this.GetRoleWithPermissionByRoleId(roleId, _dataRepositoryFactory);
        }

        public RoleDto AddAllRoles2Permission(long roleId, IUnitOfWork _dataRepositoryFactory)
        {
            IRoleRepository RoleRepo = _dataRepositoryFactory.GetRoleRepository();

            RoleDto role = this.GetRoleWithPermissionByRoleId(roleId, _dataRepositoryFactory);
            return Mapper.Map<RoleDto>(RoleRepo.AddAllPermissionToRole(Mapper.Map<Role>(role)));
        }

        public RoleDto DeletePermissionFromRole(long roleId, long permissionId, IPermissionService _permissionDomainService, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Role> RoleRepo = _dataRepositoryFactory.GetRepository<Role>();

            RoleDto role = this.GetRoleWithPermissionByRoleId(roleId, _dataRepositoryFactory);
            Permission permission = Mapper.Map<Permission>(_permissionDomainService.GetPermissionByPermissionId(permissionId, _dataRepositoryFactory));

            if (role.Permissions.Where(r => r.PermissionId == permissionId).Count() > 0)
            {
                role.Permissions.Remove(permission);
                this.UpdateRole(role, role.RoleId, _dataRepositoryFactory);                
            }

            return this.GetRoleWithPermissionByRoleId(roleId, _dataRepositoryFactory);
        }

    }
}
