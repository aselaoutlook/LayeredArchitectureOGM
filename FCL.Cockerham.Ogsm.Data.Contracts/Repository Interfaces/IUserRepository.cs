using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> AllUsers();

        User UpdateNormal(User t, long key);
    }
}
