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
    public class CarsConfiguration : IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            // Configuring primary key
            builder.HasKey(c => c.Id);

            // Configuring properties
            builder.Property(c => c.Year)
                .IsRequired();

            builder.Property(c => c.BasePrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.DateAdded)
                .IsRequired();

            builder.Property(c => c.HorsePower)
                .IsRequired();

            builder.Property(c => c.Engine)
                .HasMaxLength(50);

            builder.Property(c => c.EngineCylinder)
                .IsRequired();

            builder.Property(c => c.EngineLiter)
                .IsRequired()
                .HasColumnType("decimal(3,2)");

            builder.Property(c => c.Torque)
                .IsRequired();

            // Configuring relationships
            builder.HasMany(c => c.CarFeatures)
                .WithOne(cf => cf.Cars)
                .HasForeignKey(cf => cf.CarID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.CarModel)
                .WithMany(cm => cm.Cars)
                .HasForeignKey(c => c.CarModelID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
