// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductStore.Data;

namespace ProductStore.Data.Migrations
{
    [DbContext(typeof(PSContext))]
    [Migration("20211108114920_CategoryConf")]
    partial class CategoryConf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProvidersId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "ProvidersId");

                    b.HasIndex("ProvidersId");

                    b.ToTable("ProductProvider");
                });

            modelBuilder.Entity("ProductStore.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("MyCategories");
                });

            modelBuilder.Entity("ProductStore.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CateoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("ProductStore.Domain.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ProductStore.Domain.Entities.Biological", b =>
                {
                    b.HasBaseType("ProductStore.Domain.Entities.Product");

                    b.Property<string>("Herbs")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Biological");
                });

            modelBuilder.Entity("ProductStore.Domain.Entities.Chemical", b =>
                {
                    b.HasBaseType("ProductStore.Domain.Entities.Product");

                    b.Property<string>("LabName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Chemical");
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.HasOne("ProductStore.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductStore.Domain.Entities.Provider", null)
                        .WithMany()
                        .HasForeignKey("ProvidersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductStore.Domain.Entities.Product", b =>
                {
                    b.HasOne("ProductStore.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductStore.Domain.Entities.Chemical", b =>
                {
                    b.OwnsOne("ProductStore.Domain.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ChemicalProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetAddress")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ChemicalProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ChemicalProductId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ProductStore.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
