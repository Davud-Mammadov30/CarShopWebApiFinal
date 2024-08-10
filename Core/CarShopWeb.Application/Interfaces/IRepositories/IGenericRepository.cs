using CarShopWeb.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        Task<bool> AddAsync(T data);
        bool Update(T data);
        bool Delete(T data);
        Task<bool> DeleteById(int id);
    }
}
