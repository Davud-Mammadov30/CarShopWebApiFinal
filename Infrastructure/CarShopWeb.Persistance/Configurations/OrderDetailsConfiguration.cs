using CarShopWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Configurations
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(od => od.Id);

            builder.HasOne(od => od.Orders)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(od => od.OrderID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(od => od.Features)
                   .WithMany(f => f.OrderDetails)
                   .HasForeignKey(od => od.FeatureID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
