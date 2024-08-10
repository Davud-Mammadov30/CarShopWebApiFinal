using CarShopWeb.Application.Interfaces.IRepositories;
using CarShopWeb.Domain.Entities.Common;
using CarShopWeb.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Implementations.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDBContext _dbContext;
        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T data)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(data);
            return entityEntry.State == EntityState.Added;
        }

        public bool Delete(T data)
        {
            EntityEntry<T> entityEntry = Table.Remove(data);
            return entityEntry.State == EntityState.Deleted;

        }

        public async Task<bool> DeleteById(int id)
        {
            T entity = await Table.FindAsync(id);
            if(entity == null)
            {
                return false;
            }
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.AsQueryable().FirstOrDefaultAsync(data => data.Id == id);
        }

        public bool Update(T data)
        {
            EntityEntry<T> entityEntry = Table.Update(data);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
