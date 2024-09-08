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

            // Property configurations
            builder.Property(o => o.CustomerID)
                .IsRequired();

            builder.Property(o => o.CarID)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasOne(o => o.Customers)
                .WithMany(c => c.Orders) // Assuming Customers has a collection of Orders
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior if needed

            builder.HasMany(o => o.OrderDetails)
                .WithOne() // Assuming OrderDetails has a navigation property to Orders if needed
                .HasForeignKey(od => od.OrderID) // Ensure that OrderDetails has a foreign key property
                .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior if needed

            builder.HasMany(o => o.Payments)
                .WithOne() // Assuming Payments has a navigation property to Orders if needed
                .HasForeignKey(p => p.OrderID) // Ensure that Payments has a foreign key property
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
