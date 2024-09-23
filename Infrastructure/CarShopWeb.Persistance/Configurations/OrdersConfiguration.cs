using CarShopWeb.Domain.Entities;
using CarShopWeb.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.CustomerID).IsRequired();
            builder.Property(o => o.CarID).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(o => o.Customers)
                   .WithMany(c => c.Orders)  // Use the correct navigation property
                   .HasForeignKey(o => o.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Cars)
                   .WithMany()  // You can configure navigation on Cars as needed
                   .HasForeignKey(o => o.CarID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.OrderDetails)
                   .WithOne(od => od.Orders)  // Explicitly define the navigation property
                   .HasForeignKey(od => od.OrderID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Payments)
                   .WithOne()  // Assuming Payments has a relationship to Orders
                   .HasForeignKey(p => p.OrderID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
