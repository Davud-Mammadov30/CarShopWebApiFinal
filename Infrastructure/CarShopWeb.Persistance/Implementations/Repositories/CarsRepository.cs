﻿using CarShopWeb.Application.Interfaces.IRepositories;
using CarShopWeb.Domain.Entities;
using CarShopWeb.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Implementations.Repositories
{
    public class CarsRepository : GenericRepository<Cars>, ICarsRepository
    {
        public CarsRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            
        }
    }
}
