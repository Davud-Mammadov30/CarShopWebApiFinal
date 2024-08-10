using AutoMapper;
using CarShopWeb.Application.Interfaces.IRepositories;
using CarShopWeb.Application.Interfaces.IUnitofworks;
using CarShopWeb.Domain.Entities.Common;
using CarShopWeb.Persistence.Context;
using CarShopWeb.Persistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Implementations.Unitofwork
{
    public class Unitofwork : IUnitofwork
    {
        private readonly ApplicationDBContext _dbContext;
        private Dictionary<Type, object> _repositories;
        public Unitofwork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IGenericRepository<T> GetRepositories<T>() where T : BaseEntity
        {
            if(_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)_repositories[typeof(T)];
            }
            IGenericRepository<T> repository = new GenericRepository<T>(_dbContext);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
