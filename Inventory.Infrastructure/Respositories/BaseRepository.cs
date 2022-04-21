using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Inventory.Domain.Repositories;
using Inventory.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Respositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly InventoryDbContext Context;

        protected DbSet<TEntity> Entities;


        /// <summary>  
        /// Initializes a new instance of the <see cref="IRepository{TEntity}"/> class.  
        /// Note that here I've stored Context.Set<TEntity>() in the constructor and store it in a private field like _entities.   
        /// This way, the implementation  of our methods would be cleaner:        ///   
        /// _entities.ToList();  
        /// _entities.Where();  
        /// _entities.SingleOrDefault();  
        /// </summary>
        /// 
        public BaseRepository(InventoryDbContext _dbContext)
        {
            Context = _dbContext;
            Entities = Context.Set<TEntity>();
        }
        /// <summary>
        /// me for 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
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
        /// Gets the specified identifier.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns></returns>  
        public virtual TEntity Get(long id)
        {
            // Here we are working with a DbContext, not specific DbContext.   
            // So we don't have DbSets we need to use the generic Set() method to access them.  
            return Entities.Find(id);
        }

        /// <summary>  
        /// Gets all.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        /// <summary>  
        /// Finds the specified predicate.  
        /// </summary>  
        /// <param name="predicate">The predicate.</param>  
        /// <returns></returns>  
        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        /// <summary>  
        /// Singles the or default.  
        /// </summary>  
        /// <param name="predicate">The predicate.</param>  
        /// <returns></returns>  
        public TEntity SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).SingleOrDefault();
        }

        /// <summary>  
        /// First the or default.  
        /// </summary>  
        /// <returns></returns>  
        public TEntity FirstOrDefault()
        {
            return Entities.SingleOrDefault();
        }

        /// <summary>  
        /// Adds the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        public void Add(TEntity entity)
        {
            Entities.Add(entity);
            Context.SaveChanges();
        }

        /// <summary>  
        /// Adds the range.  
        /// </summary>  
        /// <param name="entities">The entities.</param>  
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
            Context.SaveChanges();
        }

        /// <summary>  
        /// Removes the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>  
        /// Removes the range.  
        /// </summary>  
        /// <param name="entities">The entities.</param>  
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
            Context.SaveChanges();
        }

        /// <summary>  
        /// Update the Entity  
        /// </summary>  
        /// <param name="entityToUpdate"></param>  
        public virtual void Update(TEntity entityToUpdate)
        {
            Entities.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                //query.OrderBy(orderBy)
                return await orderBy(query).ToListAsync();
            }
            else
            {
                //productQuery.Skip(25 * page).Take(25)
                return await query.ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(long id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            Entities.Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            Entities.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            Entities.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public void UpdateAll(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
            Context.SaveChanges();
        }

        public async Task UpdateAllAsync(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
            //Context.Entry(entityToUpdate).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
