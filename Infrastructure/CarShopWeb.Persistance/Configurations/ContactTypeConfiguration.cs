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
    public class ContactTypeConfiguration /*: IEntityTypeConfiguration<ContactType>*/
    {
        //public void Configure(EntityTypeBuilder<ContactType> builder)
        //{
            

        //    // Configuring primary key
        //    builder.HasKey(ct => ct.Id);

        //    // Configuring properties
        //    builder.Property(ct => ct.Number)
        //        .HasMaxLength(15); // Adjust length based on expected phone number format.

        //    builder.Property(ct => ct.WhatsAppNumber)
        //        .HasMaxLength(15); // Same as above, assuming similar phone number format.

        //    builder.Property(ct => ct.Email)
        //        .HasMaxLength(100); // Adjust length based on expected email format.

        //    // Configuring relationships
        //    builder.HasOne(ct => ct.Customers)
        //        .WithMany(c => c.ContactTypes)
        //        .HasForeignKey(ct => ct.CustomerID)
        //        .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior as needed.
        //}
    }
}
