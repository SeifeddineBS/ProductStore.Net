using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Configurations
{
    public class FactureConfigurations : IEntityTypeConfiguration<Facture>
    {
        public void Configure(EntityTypeBuilder<Facture> builder)
        {
            builder.HasKey(f => new { f.ProductFK, f.ClientFk, f.DateAchat });
        }
    }
}
