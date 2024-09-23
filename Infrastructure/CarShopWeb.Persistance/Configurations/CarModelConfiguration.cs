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
    public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            // Table name
            builder.ToTable("CarModel");

            // Primary key
            builder.HasKey(cm => cm.Id);

            // Column constraints
            builder.Property(cm => cm.Name)
                .IsRequired()  // Model name is required
                .HasMaxLength(100);  // Limit the length of the model name

            // Foreign key to CarBrand
            builder.HasOne(cm => cm.CarBrand)  // Each CarModel belongs to one CarBrand
                .WithMany(cb => cb.CarModels)  // One CarBrand has many CarModels
                .HasForeignKey(cm => cm.CarBrandID)  // Foreign key is CarBrandID
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // Index on the combination of CarBrandID and Name to ensure unique model names per brand
            builder.HasIndex(cm => new { cm.CarBrandID, cm.Name }).IsUnique();
        }
    }
}
