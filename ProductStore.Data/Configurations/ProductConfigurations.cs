using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {


        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //relation  Many to Many entre produit et provider
            builder.HasMany(prod => prod.Providers)
                .WithMany(prov => prov.Products)
                .UsingEntity(j => j.ToTable("Providings"));//renommer la table d'association


            builder.HasOne(prod => prod.Category)
                .WithMany(cat => cat.Products)

                .OnDelete(DeleteBehavior.Cascade)
                ;
        }
    }
}