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
    public class FeaturesConfiguration : IEntityTypeConfiguration<Features>
    {
        public void Configure(EntityTypeBuilder<Features> builder)
        {


            // Configuring primary key
            builder.HasKey(f => f.Id);

            // Setting up properties with constraints
            builder.Property(f => f.FutureType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.FutureName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.AdditionalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Configuring relationships
            builder.HasMany(f => f.CarFeatures)
                .WithOne()
                .HasForeignKey(cf => cf.FeatureID)
                .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior as needed.

            builder.HasMany(f => f.OrderDetails)
                .WithOne()
                .HasForeignKey(od => od.FeatureID)
                .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior as needed.
        }
    }
}
