using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Infrastructure.Implementations.Services;
using CarShopWeb.Persistence.Implementations.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentsService, PaymentsService>();
        }
    }
}
