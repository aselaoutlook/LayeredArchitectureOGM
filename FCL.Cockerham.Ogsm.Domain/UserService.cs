using AutoMapper;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IUserService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserService : IUserService
    {
        public UserDto CreateUser(UserDto _user, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            IBaseRepository<Role> RoleService = _dataRepositoryFactory.GetRepository<Role>();
            Role employeeRole = RoleService.GetSingle(i => i.RoleName.Equals("Employee"));
            _user.Roles = new List<Role>();
            _user.Roles.Add(employeeRole);
            UserDto _createdUser = Mapper.Map<UserDto>(UserService.Add(Mapper.Map<User>(_user)));

            return _createdUser;
        }

        public UserDto UpdateUser(UserDto _user, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            IBaseRepository<Role> RoleService = _dataRepositoryFactory.GetRepository<Role>();

            Role employeeRole = RoleService.GetSingle(i=>i.RoleName.Equals("Employee"));
            _user.Roles.Add(employeeRole);
            UserDto _updatedUser = Mapper.Map<UserDto>(UserService.Update(Mapper.Map<User>(_user)));

            return _updatedUser;
        }

        public UserDto UpdateUser(UserDto _user, long _userId, IUnitOfWork _dataRepositoryFactory)
        {
            IUserRepository UserService = _dataRepositoryFactory.GetUserRepository();
            IBaseRepository<Role> RoleService = _dataRepositoryFactory.GetRepository<Role>();

            Role employeeRole = RoleService.GetSingle(i => i.RoleName.Equals("Employee"));
            _user.Roles.Add(employeeRole);
            
            UserDto _updatedUser = Mapper.Map<UserDto>(UserService.UpdateNormal(Mapper.Map<User>(_user), _userId));

            //TODO: Check update function....
            //IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            //IBaseRepository<Role> RoleService = _dataRepositoryFactory.GetRepository<Role>();

            //Role employeeRole = RoleService.GetSingle(i => i.RoleName.Equals("Employee"));
            //_user.Roles.Add(employeeRole);

            //UserDto _updatedUser = Mapper.Map<UserDto>(UserService.IncludeUpdate(Mapper.Map<User>(_user), _userId, i => i.UserId.Equals(_userId), "Roles"));

            return _updatedUser;
        }

        public UserDto GetUserByUserId(long _userId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            UserDto _user = Mapper.Map<UserDto>(UserService.GetSingle(u => u.UserId.Equals(_userId), "EmployeeUser, EmployeeUser.EmployeeStrategies, Organization"));

            return _user;
        }

        public UserDto GetUserByUserIdAsTrackable(long _userId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            UserDto _user = Mapper.Map<UserDto>(UserService.GetSingleAsTrackable(u => u.UserId.Equals(_userId), "EmployeeUser, EmployeeUser.EmployeeStrategies, Organization"));

            return _user;
        }

        public LoggedInUserDto GetUserForSignInByUsername(string _username, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            LoggedInUserDto _user = Mapper.Map<LoggedInUserDto>(UserService.GetSingle(i => i.UserName.Equals(_username), "Organization, Roles"));

            return _user;
        }

        public UserDto GetUserByUsername(string _username, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            UserDto _user = Mapper.Map<UserDto>(UserService.GetSingle(i => i.UserName.Equals(_username), "Organization, Roles"));

            return _user;
        }

        public UserDto GetUserWithRoleByUserId(long id, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            UserDto _user = Mapper.Map<UserDto>(UserService.GetSingle(i => i.UserId.Equals(id), "Roles"));

            return _user;
        }

        public ICollection<UserDto> GetActiveUsers(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            ICollection<UserDto> _activeUsers = Mapper.Map<ICollection<UserDto>>(UserService.GetListWithNavigation(i => i.IsActive.Equals(true)));

            return _activeUsers;
        }

        public ICollection<UserDto> GetActiveUsers(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            ICollection<UserDto> _activeUsers = Mapper.Map<ICollection<UserDto>>(UserService.GetListWithNavigation(i => i.IsActive.Equals(true) && i.OrganizationId.Equals(_organizationId)));

            return _activeUsers;
        }

        public ICollection<UserDto> GetAllUsers(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            ICollection<UserDto> _allUsers = Mapper.Map<ICollection<UserDto>>(UserService.GetAll());

            return _allUsers;
        }

        public ICollection<UserDto> GetAllUsers(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            ICollection<UserDto> _allUsers = Mapper.Map<ICollection<UserDto>>(UserService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allUsers;
        }

        public IEnumerable<UserDto> GetFilteredUserListBySurname(string _surname, IUnitOfWork _dataRepositoryFactory)
        {

            IUserRepository UserRepo = _dataRepositoryFactory.GetUserRepository();
            IEnumerable<UserDto> _allFilteredUsers = Mapper.Map<IEnumerable<UserDto>>(UserRepo.GetList(i => i.LastName.Contains(_surname), null, ""));

            return _allFilteredUsers;
        }

        public IEnumerable<UserDto> GetFilteredUserListBySurname(string _surname, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {

            IUserRepository UserRepo = _dataRepositoryFactory.GetUserRepository();
            IEnumerable<UserDto> _allFilteredUsers = Mapper.Map<IEnumerable<UserDto>>(UserRepo.GetList(i => i.LastName.Contains(_surname) && i.OrganizationId.Equals(_organizationId), null, ""));

            return _allFilteredUsers;
        }

        public IEnumerable<UserDto> GetSearchUserListByKey(string _key, long OrgId, long SdId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            IEnumerable<UserDto> _allUsers = Mapper.Map<IEnumerable<UserDto>>(UserService.GetList(i => (i.FirstName.Contains(_key) || i.LastName.Contains(_key)) && i.OrganizationId.Equals(OrgId), q => q.OrderBy(s => s.FirstName), "EmployeeUser.EmployeeStrategies"));

            IEmployeeStrategyRepository employeeStrategyService = _dataRepositoryFactory.GetEmployeeStrategyRepository();
            List<UserDto> _allSearchUsers = new List<UserDto>();
            foreach (UserDto user in _allUsers)
            {
                if (user.EmployeeUser.Count != 0)
                {
                    EmployeeStrategy strategy = user.EmployeeUser[0].EmployeeStrategies.Where(i => i.StrategicDriverId == SdId).FirstOrDefault();

                    if (strategy == null)
                    {
                        _allSearchUsers.Add(user);
                    }
                }
                else
                {
                    _allSearchUsers.Add(user);
                }
            }

            return _allSearchUsers.AsEnumerable();
        }

        public bool CheckUserExistByUsername(string _userName, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            ICollection<UserDto> results = Mapper.Map<ICollection<UserDto>>(UserService.GetListWithNavigation(filter: i => i.UserName.Equals(_userName)));

            return (results.Count > 0);
        }

        public UserDto DeleteUserRole(long roleId, long userId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory)
        {
            IUserRepository UserRepo = _dataRepositoryFactory.GetUserRepository();
            IRoleRepository RoleRepo = _dataRepositoryFactory.GetRoleRepository();

            Role role = Mapper.Map<Role>(_roleDomainService.GetRoleWithUserByRoleId(roleId, _dataRepositoryFactory));
            User user = Mapper.Map<User>(this.GetUserByUserId(userId, _dataRepositoryFactory));

            if (role.Users.Where(u => u.UserId == userId).Count() > 0)
            {
                role.Users.Remove(user);
                _roleDomainService.UpdateRole(Mapper.Map<RoleDto>(role), role.RoleId, _dataRepositoryFactory);
            }

            return this.GetUserWithRoleByUserId(userId, _dataRepositoryFactory);
        }

        public UserDto AddUserRole(long roleId, long userId, IRoleService _roleDomainService, IUnitOfWork _dataRepositoryFactory)
        {
            IUserRepository UserRepo = _dataRepositoryFactory.GetUserRepository();
            IRoleRepository RoleRepo = _dataRepositoryFactory.GetRoleRepository();

            Role role = Mapper.Map<Role>(_roleDomainService.GetRoleWithUserByRoleId(roleId, _dataRepositoryFactory));
            User user = Mapper.Map<User>(this.GetUserByUserId(userId, _dataRepositoryFactory));

            if (!role.Users.Contains(user))
            {
                role.Users.Add(user);
                _roleDomainService.UpdateRole(Mapper.Map<RoleDto>(role), role.RoleId, _dataRepositoryFactory);
            }

            return this.GetUserWithRoleByUserId(userId, _dataRepositoryFactory);
        }

        public IEnumerable<UserDto> GetUserList(int pageNo, int pageSize, long OrgId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            IEnumerable<UserDto> _allUsers = Mapper.Map<IEnumerable<UserDto>>(UserService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(OrgId), q => q.OrderBy(s => s.FirstName), "EmployeeUser"));

            return _allUsers;
        }

        public IEnumerable<UserDto> GetAllActiveStrategicDriverEmployees(int pageNo, int pageSize, long SdId, long OrgId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            IEnumerable<UserDto> _allUsers = Mapper.Map<IEnumerable<UserDto>>(UserService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(OrgId), q => q.OrderBy(s => s.FirstName), "EmployeeUser.EmployeeStrategies"));

            IEmployeeStrategyRepository employeeStrategyService = _dataRepositoryFactory.GetEmployeeStrategyRepository();            
            List<UserDto> _allStrategyUsers = new List<UserDto>();
            foreach (UserDto user in _allUsers)
            {
                if (user.EmployeeUser.Count != 0)
                {
                    foreach (EmployeeStrategy strategy in user.EmployeeUser[0].EmployeeStrategies)
                    {
                        if (strategy.StrategicDriverId.Equals(SdId))
                        {
                            _allStrategyUsers.Add(user);
                            break;
                        }
                    }
                }
            }
            return _allStrategyUsers.AsEnumerable();
        }

        public long GetUserCount(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            return UserService.Count();
        }

        public IEnumerable<UserDto> GetActiveGoalOwnersByOrganization(long orgId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            IEnumerable<UserDto> _activeUsers = Mapper.Map<IEnumerable<UserDto>>(UserService.GetList(i => i.IsActive.Equals(true) && i.OrganizationId.Equals(orgId)));

            return _activeUsers;
        }

        public LoggedInUserDto GetUserForSignInByUsernameAndPassword(string _username, string _password, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<User> UserService = _dataRepositoryFactory.GetRepository<User>();
            LoggedInUserDto _user = Mapper.Map<LoggedInUserDto>(UserService.GetSingle(i => i.UserName.Equals(_username) && i.Password.Equals(_password), "Organization, Roles"));

            return _user;
        }
    }
}
