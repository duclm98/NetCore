﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.Data.Data;

namespace NetCore.Data.Migrations
{
    [DbContext(typeof(NetCoreDbContext))]
    [Migration("20210617085150_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCore.Data.Models.Category", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Name = "Category 1"
                        },
                        new
                        {
                            ID = 2L,
                            Name = "Category 2"
                        },
                        new
                        {
                            ID = 3L,
                            Name = "Category 3"
                        });
                });

            modelBuilder.Entity("NetCore.Data.Models.Product", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Name = "Product 1",
                            Price = 100
                        },
                        new
                        {
                            ID = 2L,
                            Name = "Product 2",
                            Price = 200
                        },
                        new
                        {
                            ID = 3L,
                            Name = "Product 3",
                            Price = 600
                        },
                        new
                        {
                            ID = 4L,
                            Name = "Product 4",
                            Price = 400
                        });
                });

            modelBuilder.Entity("NetCore.Data.Models.ProductInCategory", b =>
                {
                    b.Property<long>("CategoryID")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductID")
                        .HasColumnType("bigint");

                    b.HasKey("CategoryID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductInCategories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1L,
                            ProductID = 1L
                        },
                        new
                        {
                            CategoryID = 1L,
                            ProductID = 2L
                        },
                        new
                        {
                            CategoryID = 1L,
                            ProductID = 3L
                        },
                        new
                        {
                            CategoryID = 1L,
                            ProductID = 4L
                        },
                        new
                        {
                            CategoryID = 2L,
                            ProductID = 1L
                        },
                        new
                        {
                            CategoryID = 2L,
                            ProductID = 2L
                        },
                        new
                        {
                            CategoryID = 2L,
                            ProductID = 3L
                        },
                        new
                        {
                            CategoryID = 2L,
                            ProductID = 4L
                        },
                        new
                        {
                            CategoryID = 3L,
                            ProductID = 1L
                        },
                        new
                        {
                            CategoryID = 3L,
                            ProductID = 2L
                        },
                        new
                        {
                            CategoryID = 3L,
                            ProductID = 3L
                        },
                        new
                        {
                            CategoryID = 3L,
                            ProductID = 4L
                        });
                });

            modelBuilder.Entity("NetCore.Data.Models.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NetCore.Data.Models.ProductInCategory", b =>
                {
                    b.HasOne("NetCore.Data.Models.Category", "Category")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetCore.Data.Models.Product", "Product")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NetCore.Data.Models.Category", b =>
                {
                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("NetCore.Data.Models.Product", b =>
                {
                    b.Navigation("ProductInCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
