using CarShopWeb.Application;
using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Application.Interfaces.IUnitofworks;
using CarShopWeb.Domain.Entities.Identity;
using CarShopWeb.Infrastructure.Implementations.Services;
using CarShopWeb.Persistence.Context;
using CarShopWeb.Persistence.Implementations.Services;
using CarShopWeb.Persistence.Implementations.Unitofwork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CarShopWeb.Persistence.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarsService, CarsService>();
            services.AddScoped<IFeaturesService, FeaturesService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IAccountDetailService,AccountDetailsService>();
            services.AddScoped<IContactTypeService, ContactTypeService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IUnitofwork, Unitofwork>();
            services.AddScoped<ICarBrandService, CarBrandService>();
            services.AddScoped<ICarModelService, CarModelService>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDefault")));

            //var reg = new Class1();
            //reg.Class(services);
        }

        public static void AddPersistanServices()
        {
            //var ne
            //services.AddScoped<IPaymentsService, PaymentsService>();
        }
    }
}
