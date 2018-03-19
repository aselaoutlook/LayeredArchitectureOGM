#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data
///MODULE        :         
///SUB MODULE    :    
///Class         : BaseRepository
///AUTHOR        : Asela Chamara      
///CREATED       : 11/15/2015        
///DESCRIPTION   : Purpose is to provide a generic repository for .NET Entity Framework 6.x 
///MODIFICATION HISTORY:  
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Web.Framework.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FCL.Cockerham.Ogsm.Data
{
    //public class BaseRepository<TEntity> where TEntity : class
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Variable to hold the FclDBContext
        /// </summary>
        protected internal FclDBContext context;

        /// <summary>
        /// Variable to hold entity set of the FclDBContext
        /// </summary>
        protected internal DbSet<TEntity> dbSet;

        /// <summary>
        /// The contructor requires an open DataContext to work with
        /// </summary>
        /// <param name="context">An open DataContext</param>
        /// <param name="dbSet">An Entity set instance of the context</param>
        public BaseRepository(FclDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        #region Sync
        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="key">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public virtual TEntity GetSingle(object key)
        {
            return dbSet.Find(key);
        }

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided filter expression and ordered By orderBy expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <param name="includeProperties">Which propertes to include in the result set</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty).AsNoTracking();
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided filter expression and ordered By orderBy expression as Trackable collection.
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <param name="includeProperties">Which propertes to include in the result set</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        public virtual TEntity GetSingleAsTrackable(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public virtual ICollection<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public virtual ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Where(filter).ToList();
        }

        /// <summary>
        /// Gets a collection of all objects in the database with navigation properties
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter.
        /// If more than one object is found or if zero are found, null is returned</returns>
        public virtual ICollection<TEntity> GetListWithNavigation(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = filter == null ? this.context.Set<TEntity>() : this.context.Set<TEntity>().Where(filter);
            var workspace = ((IObjectContextAdapter)this.context).ObjectContext.MetadataWorkspace;
            var itemCollection = (ObjectItemCollection)(workspace.GetItemCollection(DataSpace.OSpace));
            var entityType = itemCollection.OfType<EntityType>().FirstOrDefault(e => itemCollection.GetClrType(e) == typeof(TEntity));

            if (entityType != null)
            {
                foreach (var navigationProperty in entityType.NavigationProperties)
                {
                    query = query.Include(navigationProperty.Name);
                }
            }
            return query.ToList();
        }

        /// <summary>
        /// Returns a collection of objects which match the provided expression without navigation propertes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public virtual ICollection<TEntity> GetListWithoutNavigation(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Where(filter).ToList();
        }

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided raw Sql querry
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="query">A Sql Statement get results</param>
        /// <param name="parameters">object[] of parameters</param>
        /// <returns>An IEnumerable of object which match the sql statement</returns>
        public virtual IEnumerable<TEntity> GetListWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided filter expression and ordered By orderBy expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <param name="orderBy">A linq expression filter to order the results</param>
        /// <param name="includeProperties">Which propertes to include in the result set</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        public virtual IEnumerable<TEntity> GetList( Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty).AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided filter expression and ordered By orderBy expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <param name="orderBy">A linq expression filter to order the results</param>
        /// <param name="includeProperties">Which propertes to include in the result set</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        public virtual IEnumerable<TEntity> GetPagedList(int skip, int pageSize, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty).AsNoTracking();
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                return query.ToList().Skip(skip).Take(pageSize);
            }
        }  

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public virtual TEntity Add(TEntity t)
        {
            dbSet.Add(t);
            context.SaveChanges();
            return t;
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> tList)
        {
            dbSet.AddRange(tList);
            context.SaveChanges();
            return tList;
        }

        /// <summary>
        /// Updates a single object and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The updated object to apply to the database</param>
        /// <returns>The resulting updated object</returns>
        public virtual TEntity Update(TEntity t)
        {
            try
            {
                dbSet.Attach(t);
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();
                return t;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public virtual TEntity Update(TEntity t, long key)
        {
            if (t == null)
                return null;

            TEntity existing = dbSet.Find(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(t);
                context.SaveChanges();
            }
            return existing;

        }

        public virtual TEntity IncludeUpdate(TEntity t, long key, Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            TEntity existing = query.FirstOrDefault();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                context.Entry(existing).Collection(includeProperty).EntityEntry.CurrentValues.SetValues(t.GetType().GetProperty(includeProperty));
                context.Entry(existing).Collection(includeProperty).EntityEntry.State = EntityState.Modified;
            }

            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(t);
                context.SaveChanges();

                //context.Entry(existing).CurrentValues.SetValues(t);
                //foreach (Role role in t.Roles)
                //{
                //    if (!existing.Roles.Contains(role))
                //    {
                //        existing.Roles.Add(role);
                //    }
                //}
            }

            return existing;
        }

        //public virtual User UpdateNormal(User t, long key)
        //{
        //    //if (t == null)
        //    //    return null; 

        //    //TEntity existing = dbSet.Find(key);
        //    User existing = context.Users.Find(key);
        //    //if (existing != null)
        //    //{
        //    //    context.Entry(existing).CurrentValues.SetValues(t);
        //    //    context.SaveChanges();
        //    //}

        //    context.Entry(existing).CurrentValues.SetValues(t);
        //    context.Entry(t.Roles).State = EntityState.Added;
        //    context.SaveChanges();

        //    return existing;

        //}

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to delete</param>
        public virtual void Delete(TEntity t)
        {
            dbSet.Remove(t);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes a single object from the database with a primary key of the provided id and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="key">The primary key of the deleting object</param>
        public virtual void Delete(object key)
        {
            TEntity t = dbSet.Find(key);
            dbSet.Remove(t);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public virtual long Count()
        {
            return dbSet.Count();
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse table according to filter
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public virtual long Count(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }
        #endregion

        #region Async
        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="key">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public virtual async Task<TEntity> GetSingleAsync(long key)
        {
            return await dbSet.FindAsync(key);
        }

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="filter">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dbSet.SingleOrDefaultAsync(filter);
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        
        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dbSet.Where(filter).ToListAsync();
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public virtual async Task<TEntity> AddAsync(TEntity t)
        {
            dbSet.Add(t);
            await context.SaveChangesAsync();
            return t;
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public virtual async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> tList)
        {
            dbSet.AddRange(tList);
            await context.SaveChangesAsync();
            return tList;
        }

        /// <summary>
        /// Updates a single object and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <returns>The resulting updated object</returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity t)
        {
            dbSet.Attach(t);
            await context.SaveChangesAsync();
            return t;
        }

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity t, long key)
        {
            if (t == null)
                return null;

            TEntity existing = await dbSet.FindAsync(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(t);
                await context.SaveChangesAsync();
            }
            return existing;
        }

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to delete</param>
        public virtual async Task<long> DeleteAsync(TEntity t)
        {
            dbSet.Remove(t);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a single object from the database with a primary key of the provided id and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="key">The primary key of the deleting object</param>
        public virtual async Task<long> DeleteAsync(object key)
        {
            TEntity t = dbSet.Find(key);
            dbSet.Remove(t);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public virtual async Task<long> CountAsync()
        {
            return await dbSet.CountAsync();
        }
        #endregion
    }
}
