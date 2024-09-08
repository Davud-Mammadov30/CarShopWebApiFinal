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
    public class CarFeaturesConfiguration : IEntityTypeConfiguration<CarFeatures>
    {
        public void Configure(EntityTypeBuilder<CarFeatures> builder)
        {


            // Configuring primary key
            builder.HasKey(cf => cf.Id);

            // Configuring properties
            builder.Property(cf => cf.CarID)
                .IsRequired();

            builder.Property(cf => cf.FeatureID)
                .IsRequired();

            // Configuring relationships
            builder.HasOne(cf => cf.Cars)
                .WithMany(c => c.CarFeatures)
                .HasForeignKey(cf => cf.CarID)
                .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior as needed.

            builder.HasOne(cf => cf.Features)
                .WithMany(f => f.CarFeatures)
                .HasForeignKey(cf => cf.FeatureID)
                .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior as needed.
        }
    }
}
