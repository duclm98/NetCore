﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.Data.Context;

namespace NetCore.Data.Migrations
{
    [DbContext(typeof(NetCoreDbContext))]
    [Migration("20220107095205_UpdateDB_Audit_Log")]
    partial class UpdateDB_Audit_Log
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCore.Data.Entities.AuditLog", b =>
                {
                    b.Property<int>("AuditLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColumnName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AuditLogId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CreatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(1148),
                            Name = "Category 1",
                            UpdatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(7893)
                        },
                        new
                        {
                            CategoryId = 2,
                            CreatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(8522),
                            Name = "Category 2",
                            UpdatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(8527)
                        },
                        new
                        {
                            CategoryId = 3,
                            CreatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(8539),
                            Name = "Category 3",
                            UpdatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(8540)
                        });
                });

            modelBuilder.Entity("NetCore.Data.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CreatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(6606),
                            Name = "Product 1",
                            Price = 100,
                            UpdatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(6613)
                        },
                        new
                        {
                            ProductId = 2,
                            CreatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7256),
                            Name = "Product 2",
                            Price = 200,
                            UpdatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7259)
                        },
                        new
                        {
                            ProductId = 3,
                            CreatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7279),
                            Name = "Product 3",
                            Price = 600,
                            UpdatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7280)
                        },
                        new
                        {
                            ProductId = 4,
                            CreatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7281),
                            Name = "Product 4",
                            Price = 400,
                            UpdatedAt = new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7282)
                        });
                });

            modelBuilder.Entity("NetCore.Data.Entities.ProductInCategory", b =>
                {
                    b.Property<int>("ProductInCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductInCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductInCategories");
                });

            modelBuilder.Entity("NetCore.Data.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NetCore.Data.Entities.ProductInCategory", b =>
                {
                    b.HasOne("NetCore.Data.Entities.Category", "Category")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("NetCore.Data.Entities.Product", "Product")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Category", b =>
                {
                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Product", b =>
                {
                    b.Navigation("ProductInCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
