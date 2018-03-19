using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IRoleService
    {
        RoleDto CreateRole(RoleDto _role, IUnitOfWork _dataRepositoryFactory);

        RoleDto GetRoleByRoleId(long _roleId, IUnitOfWork _dataRepositoryFactory);

        RoleDto GetRoleByRoleName(string _roleName, IUnitOfWork _dataRepositoryFactory);

        ICollection<RoleDto> GetAllRoles(IUnitOfWork _dataRepositoryFactory);

        RoleDto GetRoleWithUserByRoleId(long _roleId, IUnitOfWork _dataRepositoryFactory);

        RoleDto GetRoleWithPermissionByRoleId(long _roleId, IUnitOfWork _dataRepositoryFactory);

        RoleDto GetRoleWithDifinedNavigationByRoleId(long id, string navigationProperties, IUnitOfWork _dataRepositoryFactory);

        RoleDto UpdateRole(RoleDto _role, IUnitOfWork _dataRepositoryFactory);

        RoleDto UpdateRole(RoleDto _role, long _roleId, IUnitOfWork _dataRepositoryFactory);

        bool DeleteRole(long roleId, IUnitOfWork _dataRepositoryFactory);

        RoleDto DeleteRoleUser(long roleId, long userId, IUserService _userDomainService, IUnitOfWork _dataRepositoryFactory);

        RoleDto AddRoleUser(long roleId, long userId, IUserService _userDomainService, IUnitOfWork _dataRepositoryFactory);

        RoleDto AddRole2Permission(long roleId, long permissionId, IPermissionService _permissionDomainService, IUnitOfWork _dataRepositoryFactory);

        RoleDto AddAllRoles2Permission(long roleId, IUnitOfWork _dataRepositoryFactory);

        RoleDto DeletePermissionFromRole(long roleId, long permissionId, IPermissionService _permissionDomainService, IUnitOfWork _dataRepositoryFactory);
    }
}
