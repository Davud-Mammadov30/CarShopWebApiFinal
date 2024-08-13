using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace CarShopWeb.Application.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            
            ///services.AddPersistanceServices();
        }
    }
}
