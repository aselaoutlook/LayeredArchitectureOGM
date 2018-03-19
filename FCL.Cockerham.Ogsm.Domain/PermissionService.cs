using AutoMapper;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IPermissionService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PermissionService : IPermissionService
    {
        public PermissionDto CreatePermission(PermissionDto _permission, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            PermissionDto _createdPermission = Mapper.Map<PermissionDto>(PermissionRepo.Add(Mapper.Map<Permission>(_permission)));

            return _createdPermission;
        }

        public ICollection<PermissionDto> GetAllPermission(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            ICollection<PermissionDto> _allRoles = Mapper.Map<ICollection<PermissionDto>>(PermissionRepo.GetAll());

            return _allRoles;
        }

        public IEnumerable<PermissionDto> GetPermissionListWithDifinedNavigation(string navigationProperties, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            IEnumerable<PermissionDto> _permission = Mapper.Map<IEnumerable<PermissionDto>>(PermissionRepo.GetList(null, i => i.OrderBy(p => p.PermissionDescription), navigationProperties));

            return _permission;
        }

        public PermissionDto GetPermissionWithDefinedNavigationByPermissionId(long id, string navigationProperties, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            PermissionDto _permission = Mapper.Map<PermissionDto>(PermissionRepo.GetSingle(i => i.PermissionId.Equals(id), navigationProperties));

            return _permission;
        }

        public PermissionDto GetPermissionWithRoleByPermissionId(long _permissionId, IUnitOfWork _dataRepositoryFactory)
        {
            IPermissionRepository PermissionService = _dataRepositoryFactory.GetPermissionRepository();
            PermissionDto _permission = Mapper.Map<PermissionDto>(PermissionService.GetSingle(i => i.PermissionId.Equals(_permissionId), "Roles"));

            return _permission;
        }

        public PermissionDto GetPermissionByPermissionId(long _permissionId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            PermissionDto _permission = Mapper.Map<PermissionDto>(PermissionRepo.GetSingle(_permissionId));

            return _permission;
        }

        public PermissionDto GetPermissionByPermissionDescription(string _permissionDescription, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            PermissionDto _permission = Mapper.Map<PermissionDto>(PermissionRepo.GetSingle(p => p.PermissionDescription.Equals(_permissionDescription)));

            return _permission;
        }

        public PermissionDto UpdatePermission(PermissionDto _permission, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            PermissionDto _updatedPermission = Mapper.Map<PermissionDto>(PermissionRepo.Update(Mapper.Map<Permission>(_permission)));

            return _updatedPermission;
        }

        public PermissionDto UpdatePermission(PermissionDto _permission, long _permissionId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            PermissionDto _updatedPermission = Mapper.Map<PermissionDto>(PermissionRepo.Update(Mapper.Map<Permission>(_permission), _permissionId));

            return _updatedPermission;
        }

        public bool DeletePermission(long permissionId, IUnitOfWork _dataRepositoryFactory)
        {
            IPermissionRepository permissionRepo = _dataRepositoryFactory.GetPermissionRepository();
            PermissionDto permission = this.GetPermissionWithDifinedNavigationByPermissionId(permissionId, "Roles", _dataRepositoryFactory);

            if (permission != null)
            {
                if (permission.Roles.Count > 0)
                {
                    permission.Roles.Clear();
                }

                permissionRepo.Delete(permission);
                return true;
            }
            else
            {
                return false;
            }
        }

        public PermissionDto GetPermissionWithDifinedNavigationByPermissionId(long id, string navigationProperties, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Permission> PermissionRepo = _dataRepositoryFactory.GetRepository<Permission>();
            PermissionDto _permission = Mapper.Map<PermissionDto>(PermissionRepo.GetSingle(i => i.PermissionId.Equals(id), navigationProperties));

            return _permission;
        }

        public PermissionDto AddPermission2Role(long permissionId, long roleId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory)
        {
            
            RoleDto role = Mapper.Map<RoleDto>(_roleDomainService.GetRoleWithDifinedNavigationByRoleId(roleId, "Permissions", _dataRepositoryFactory));
            Permission permission = Mapper.Map<Permission>(this.GetPermissionByPermissionId(permissionId, _dataRepositoryFactory));

            if (!role.Permissions.Contains(permission))
            {
                role.Permissions.Add(permission);
                _roleDomainService.UpdateRole(role, role.RoleId, _dataRepositoryFactory);
            }

            return this.GetPermissionWithRoleByPermissionId(permissionId, _dataRepositoryFactory);
        }

        public PermissionDto DeleteRoleFromPermission(long roleId, long permissionId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory)
        {
            IRoleRepository RoleRepo = _dataRepositoryFactory.GetRoleRepository();

            RoleDto role = Mapper.Map<RoleDto>(_roleDomainService.GetRoleWithDifinedNavigationByRoleId(roleId, "Users, Permissions", _dataRepositoryFactory));
            Permission permission = Mapper.Map<Permission>(this.GetPermissionByPermissionId(permissionId, _dataRepositoryFactory));

            if (role.Permissions.Where(r => r.PermissionId == permissionId).Count() > 0)
            {
                role.Permissions.Remove(permission);
                _roleDomainService.UpdateRole(role, role.RoleId, _dataRepositoryFactory);
            }

            return this.GetPermissionWithRoleByPermissionId(permissionId, _dataRepositoryFactory);
        }

        public PermissionDto AddRole2Permission(long permissionId, long roleId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory)
        {           
            RoleDto role = Mapper.Map<RoleDto>(_roleDomainService.GetRoleWithDifinedNavigationByRoleId(roleId, "Permissions", _dataRepositoryFactory));
            Permission permission = Mapper.Map<Permission>(this.GetPermissionByPermissionId(permissionId, _dataRepositoryFactory));

            if (!role.Permissions.Contains(permission))
            {
                role.Permissions.Add(permission);
                _roleDomainService.UpdateRole(role, role.RoleId, _dataRepositoryFactory);
            }

            return this.GetPermissionWithRoleByPermissionId(permissionId, _dataRepositoryFactory);
        }

        public bool ImportPermissions(Dictionary<Type, IEnumerable<MethodInfo>> controllerMethods, IUnitOfWork _dataRepositoryFactory)
        {
            foreach (var controller in controllerMethods)
            {
                string controllerName = controller.Key.Name;
                foreach (var controllerAction in controller.Value)
                {
                    string controllerActionName = controllerAction.Name;
                    if (controllerName.EndsWith("Controller"))
                    {
                        controllerName = controllerName.Substring(0, controllerName.LastIndexOf("Controller"));
                    }

                    string permissionDescription = string.Format("{0}-{1}", controllerName, controllerActionName);
                    PermissionDto permission = this.GetPermissionByPermissionDescription(permissionDescription, _dataRepositoryFactory);
                    if (permission == null)
                    {
                        
                            PermissionDto perm = new PermissionDto();
                            perm.PermissionDescription = permissionDescription;
                            this.CreatePermission(perm, _dataRepositoryFactory);
                    }
                }
            }
            return true;
        }
    }
}
