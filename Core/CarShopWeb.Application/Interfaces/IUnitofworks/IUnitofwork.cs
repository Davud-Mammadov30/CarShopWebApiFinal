using CarShopWeb.Application.Interfaces.IRepositories;
using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IUnitofworks
{
    public interface IUnitofwork : IDisposable
    {
        IGenericRepository<T> GetRepositories<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
