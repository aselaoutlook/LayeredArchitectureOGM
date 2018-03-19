#region Header
///-------------------------------------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Data_Repositories
///MODULE        :         
///SUB MODULE    :    
///Class         : UserRepository
///AUTHOR        : Asela Chamara      
///CREATED       : 05/10/2015
///LAST EDITED   : 11/28/2015
///DESCRIPTION   : Purpose is to provide a repository class to override existing BaseRepository methods or create specific 
///              : methods to save/ mofyfy/ retrive data related to FCL.Cockerham.Ogsm.Entities.User entity   
///MODIFICATION HISTORY:  V2
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using System.Linq;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using System.Data.Entity;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FclDBContext context)
            : base(context)
        {
        }

        public List<User> AllUsers()
        {
            return (from e in context.Users select e).ToList();
        }

        public User UpdateNormal(User t, long key)
        {
            //if (t == null)
            //    return null; 

            //TEntity existing = dbSet.Find(key);
            User existing = context.Users.Include("Roles").Where(i=>i.UserId.Equals(key)).FirstOrDefault();
            //if (existing != null)
            //{
            //    context.Entry(existing).CurrentValues.SetValues(t);
            //    context.SaveChanges();
            //}

            context.Entry(existing).CurrentValues.SetValues(t);
            foreach (Role role in t.Roles)
            {
                if (!existing.Roles.Contains(role))
                {
                    existing.Roles.Add(role);
                }
            }

            //context.Entry(t.Roles).State = EntityState.Added;
            context.SaveChanges();

            return existing;

        }
    }
}
