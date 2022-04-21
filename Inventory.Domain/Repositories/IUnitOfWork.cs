using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Domain.Entities;

namespace Inventory.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : EntityBase;
        void Add<T>(T entity) where T : EntityBase;
        Task AddAsync<T>(T entity) where T : EntityBase;
        void AddAll<T>(IEnumerable<T> entities) where T : EntityBase;
        Task AddAllAsync<T>(IEnumerable<T> entities) where T : EntityBase;
        void Update<T>(T entity) where T : EntityBase;
        void UpdateAll<T>(IEnumerable<T> entities) where T : EntityBase;
        void Save();
        Task SaveAsync();
    }
}
