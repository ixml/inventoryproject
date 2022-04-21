using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Domain.Entities;
using Inventory.Domain.Repositories;
using Inventory.Infrastructure.Respositories;
using Inventory.Infrastructure.Services;

namespace Inventory.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private InventoryDbContext context;
        //private DbSet entity;

        public UnitOfWork(InventoryDbContext _context)
        {
            context = _context;
            //context.c
            //entity = context.Set(typeof(EntityBase));
        }

        public void Add<T>(T entity) where T : EntityBase
        {
            context.Set<T>().Add(entity);
        }

        public void AddAll<T>(IEnumerable<T> entities) where T : EntityBase
        {
            context.Set<T>().AddRange(entities);
        }

        public IRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new BaseRepository<T>(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : EntityBase
        {
            context.Set<T>().Update(entity);
            //throw new NotImplementedException();
        }

        public void UpdateAll<T>(IEnumerable<T> entities) where T : EntityBase
        {
            context.Set<T>().UpdateRange(entities);
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task AddAsync<T>(T entity) where T : EntityBase
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task AddAllAsync<T>(IEnumerable<T> entities) where T : EntityBase
        {
            await context.Set<T>().AddRangeAsync(entities);
        }


        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
