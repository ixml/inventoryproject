using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        Task<IEnumerable<TEntity>> GetAsync(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = "");


        TEntity Get(long id);


        Task<TEntity> GetAsync(long id);

 
        IEnumerable<TEntity> GetAll();


        Task<IEnumerable<TEntity>> GetAllAsync();


        IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);


        Task<IEnumerable<TEntity>> FindAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);


        TEntity SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);


        Task AddAsync(TEntity entity);


        void AddRange(IEnumerable<TEntity> entities);


        Task AddRangeAsync(IEnumerable<TEntity> entities);

  
        void Remove(TEntity entity);


        Task RemoveAsync(TEntity entity);


        void RemoveRange(IEnumerable<TEntity> entities);

 
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);


        void Update(TEntity entityToUpdate);
        void UpdateAll(IEnumerable<TEntity> entities);
        Task UpdateAllAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entityToUpdate);

    }
}
