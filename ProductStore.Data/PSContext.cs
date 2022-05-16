using Microsoft.EntityFrameworkCore;
using ProductStore.Data.Configurations;
using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductStore.Data
{
    public class PSContext : DbContext
    {

        //ctor

        public PSContext()
        {
      // Database.EnsureCreated();// permet la création de BDD pour la 1ère fois 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Biological> Biologicals { get; set; }

        public DbSet<Chemical> Chemicals { get; set; }

        public DbSet<Facture> Factures { get; set; }

        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog=ProductStoreDB-4BI7;
                       Integrated Security=true;MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new ChemicalConfigurations());
            modelBuilder.ApplyConfiguration(new FactureConfigurations());

            //config du toutes les props name
            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(string) && p.Name.StartsWith("Name")))
            {
                property.SetColumnName("MyName");
            }

            //TPH

            //modelBuilder.Entity<Product>()
            //    .HasDiscriminator<int>("IsBiological")
            //    .HasValue<Product>(0)
            //    .HasValue<Biological>(1)
            //    .HasValue<Chemical>(2);

            //Table per Type : TPT
            modelBuilder.Entity<Chemical>().ToTable("Chemicals");
            modelBuilder.Entity<Biological>().ToTable("Biologicals");

        }
        }
}
