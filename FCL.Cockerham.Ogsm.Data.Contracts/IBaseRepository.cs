#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Contracts
///MODULE        :         
///SUB MODULE    :    
///Class         : IBaseRepository
///AUTHOR        : Asela Chamara      
///CREATED       : 11/18/2015      
///DESCRIPTION   : Purpose is to provide a interface to FCL.Cockerham.Ogsm.Data.BaseRepository class (a generic repository class for .NET Entity Framework 6.x)
///MODIFICATION HISTORY:  
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using FCL.Cockerham.Ogsm.Entities;
using FCL.Web.Framework.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FCL.Cockerham.Ogsm.Data.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        //User UpdateNormal(TEntity t, long key);

        #region Sync
        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="key">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        TEntity GetSingle(object key);

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided filter expression and ordered By orderBy expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <param name="includeProperties">Which propertes to include in the result set</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided filter expression and ordered By orderBy expression as Trackable collection.
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <param name="includeProperties">Which propertes to include in the result set</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        TEntity GetSingleAsTrackable(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        ICollection<TEntity> GetAll();

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Gets a collection of all objects in the database with navigation properties
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter.
        /// If more than one object is found or if zero are found, null is returned</returns>
        ICollection<TEntity> GetListWithNavigation(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Returns a collection of objects which match the provided expression without navigation propertes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        ICollection<TEntity> GetListWithoutNavigation(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided raw Sql querry
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="query">A Sql Statement get results</param>
        /// <param name="parameters">object[] of parameters</param>
        /// <returns>An IEnumerable of object which match the sql statement</returns>
        IEnumerable<TEntity> GetListWithRawSql(string query, params object[] parameters);

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided filter expression and ordered By orderBy expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <param name="orderBy">A linq expression filter to order the results</param>
        /// <param name="includeProperties">Which propertes to include in the result set</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// Returns a IEnumerable of objects which match the provided filter expression and ordered By orderBy expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filter">A linq expression filter to find one or more results</param>
        /// <param name="orderBy">A linq expression filter to order the results</param>
        /// <param name="includeProperties">Which propertes to include in the result set</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        IEnumerable<TEntity> GetPagedList(int skip, int pageSize, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        TEntity Add(TEntity t);

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        IEnumerable<TEntity> Add(IEnumerable<TEntity> tList);

        /// <summary>
        /// Updates a single object and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The updated object to apply to the database</param>
        /// <returns>The resulting updated object</returns>
        TEntity Update(TEntity t);

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        TEntity Update(TEntity t, long key);

        TEntity IncludeUpdate(TEntity t, long key, Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to delete</param>
        void Delete(TEntity t);

        /// <summary>
        /// Deletes a single object from the database with a primary key of the provided id and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="key">The primary key of the deleting object</param>
        void Delete(object key);

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        long Count();

        /// <summary>
        /// Gets the count of the number of objects in the databse according to the given filter
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        long Count(Expression<Func<TEntity, bool>> filter);
        #endregion

        #region Async
        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="key">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        Task<TEntity> GetSingleAsync(long key);

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="filter">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        Task<TEntity> AddAsync(TEntity t);

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> tList);

        /// <summary>
        /// Updates a single object and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <returns>The resulting updated object</returns>
        Task<TEntity> UpdateAsync(TEntity t);

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        Task<TEntity> UpdateAsync(TEntity t, long key);

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to delete</param>
        Task<long> DeleteAsync(TEntity t);

        /// <summary>
        /// Deletes a single object from the database with a primary key of the provided id and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="key">The primary key of the deleting object</param>
        Task<long> DeleteAsync(object key);

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        Task<long> CountAsync();
        #endregion
    }
}
