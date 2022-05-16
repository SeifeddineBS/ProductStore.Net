using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Configurations
{
    public class ChemicalConfigurations : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            builder.OwnsOne(ch => ch.Address)
            .Property(ad => ad.City)
            .HasColumnName("MyCity").IsRequired();


            builder.OwnsOne(ch => ch.Address)
           .Property(ad => ad.StreetAddress)
           .HasColumnName("StreetAddress").HasMaxLength(50);
        }
    }
}
