using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IPermissionService
    {
        PermissionDto CreatePermission(PermissionDto _permission, IUnitOfWork _dataRepositoryFactory);

        ICollection<PermissionDto> GetAllPermission(IUnitOfWork _dataRepositoryFactory);

        IEnumerable<PermissionDto> GetPermissionListWithDifinedNavigation(string navigationProperties, IUnitOfWork _dataRepositoryFactory);

        PermissionDto GetPermissionWithDefinedNavigationByPermissionId(long id, string navigationProperties, IUnitOfWork _dataRepositoryFactory);

        PermissionDto GetPermissionByPermissionId(long _permissionId, IUnitOfWork _dataRepositoryFactory);

        PermissionDto UpdatePermission(PermissionDto _permission, IUnitOfWork _dataRepositoryFactory);

        PermissionDto UpdatePermission(PermissionDto _permission, long _roleId, IUnitOfWork _dataRepositoryFactory);

        bool DeletePermission(long permissionId, IUnitOfWork _dataRepositoryFactory);

        PermissionDto GetPermissionWithDifinedNavigationByPermissionId(long id, string navigationProperties, IUnitOfWork _dataRepositoryFactory);

        PermissionDto GetPermissionWithRoleByPermissionId(long _permissionId, IUnitOfWork _dataRepositoryFactory);

        PermissionDto AddPermission2Role(long permissionId, long roleId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory);

        PermissionDto DeleteRoleFromPermission(long roleId, long permissionId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory);

        PermissionDto AddRole2Permission(long permissionId, long roleId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory);

        bool ImportPermissions(Dictionary<Type, IEnumerable<MethodInfo>> controllerMethods, IUnitOfWork _dataRepositoryFactory);
    }
}
