using CarShopWeb.Domain.Entities;
using CarShopWeb.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarShopWeb.Persistence.Context
{
    public class ApplicationDBContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<CarFeatures> CarFeatures { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<AccountDetail> AccountDetail { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
