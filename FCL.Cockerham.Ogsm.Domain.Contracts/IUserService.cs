using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IUserService
    {
        UserDto CreateUser(UserDto user, IUnitOfWork _dataRepositoryFactory);

        UserDto UpdateUser(UserDto _user, IUnitOfWork _dataRepositoryFactory);

        UserDto UpdateUser(UserDto _user, long _userId, IUnitOfWork _dataRepositoryFactory);

        UserDto GetUserByUserId(long _userId, IUnitOfWork _dataRepositoryFactory);

        UserDto GetUserByUserIdAsTrackable(long _userId, IUnitOfWork _dataRepositoryFactory);

        ICollection<UserDto> GetActiveUsers(IUnitOfWork _dataRepositoryFactory);

        ICollection<UserDto> GetActiveUsers(long _organizationId, IUnitOfWork _dataRepositoryFactory);

        ICollection<UserDto> GetAllUsers(IUnitOfWork _dataRepositoryFactory);

        ICollection<UserDto> GetAllUsers(long _organizationId, IUnitOfWork _dataRepositoryFactory);

        IEnumerable<UserDto> GetUserList(int pageNo, int pageSize, long OrgId, IUnitOfWork _dataRepositoryFactory);

        IEnumerable<UserDto> GetAllActiveStrategicDriverEmployees(int pageNo, int pageSize, long SdId, long OrgId, IUnitOfWork _dataRepositoryFactory);

        UserDto GetUserWithRoleByUserId(long id, IUnitOfWork _dataRepositoryFactory);

        LoggedInUserDto GetUserForSignInByUsername(string _username, IUnitOfWork _dataRepositoryFactory);

        UserDto GetUserByUsername(string _username, IUnitOfWork _dataRepositoryFactory);

        IEnumerable<UserDto> GetFilteredUserListBySurname(string _surname, IUnitOfWork _dataRepositoryFactory);

        IEnumerable<UserDto> GetFilteredUserListBySurname(string _surname, long _organizationId, IUnitOfWork _dataRepositoryFactory);

        IEnumerable<UserDto> GetSearchUserListByKey(string _key, long OrgId, long SdId, IUnitOfWork _dataRepositoryFactory);

        bool CheckUserExistByUsername(string _userName, IUnitOfWork _dataRepositoryFactory);

        UserDto AddUserRole(long roleId, long userId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory);

        UserDto DeleteUserRole(long roleId, long userId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory);

        long GetUserCount(IUnitOfWork _dataRepositoryFactory);

        IEnumerable<UserDto> GetActiveGoalOwnersByOrganization(long _organizationId, IUnitOfWork _dataRepositoryFactory);

        LoggedInUserDto GetUserForSignInByUsernameAndPassword(string _username, string _password, IUnitOfWork _dataRepositoryFactory);
    }
}
