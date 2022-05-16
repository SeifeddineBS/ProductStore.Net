using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("MyCategories");
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
        }
    }
}
