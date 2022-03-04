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
    [Migration("20220304085014_UpdateDB_AddTable_Invoice")]
    partial class UpdateDB_AddTable_Invoice
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
                        .HasColumnType("datetime");

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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AuditLogId");

                    b.HasIndex("UserId");

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

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2434),
                            Name = "Category 1",
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2441)
                        },
                        new
                        {
                            CategoryId = 2,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2919),
                            Name = "Category 2",
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2923)
                        },
                        new
                        {
                            CategoryId = 3,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2934),
                            Name = "Category 3",
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2935)
                        });
                });

            modelBuilder.Entity("NetCore.Data.Entities.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

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

                    b.HasIndex("CreatorId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3289),
                            Name = "Product 1",
                            Price = 100,
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3292)
                        },
                        new
                        {
                            ProductId = 2,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3856),
                            Name = "Product 2",
                            Price = 200,
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3859)
                        },
                        new
                        {
                            ProductId = 3,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3877),
                            Name = "Product 3",
                            Price = 600,
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3878)
                        },
                        new
                        {
                            ProductId = 4,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3879),
                            Name = "Product 4",
                            Price = 400,
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3880)
                        },
                        new
                        {
                            ProductId = 5,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3881),
                            Name = "Product 5",
                            Price = 900,
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3882)
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

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductInCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

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

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

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
                        .HasDefaultValue(2);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 839, DateTimeKind.Local).AddTicks(8870),
                            Password = "$2a$05$pUOMJMojqb9AEY9ua8mMTOqa70Qyq4kFMiCWKPS8VaCh2N27OP6Ou",
                            Role = 0,
                            UpdatedAt = new DateTime(2022, 3, 4, 15, 50, 13, 840, DateTimeKind.Local).AddTicks(4523),
                            Username = "duclm21"
                        });
                });

            modelBuilder.Entity("NetCore.Data.Entities.AuditLog", b =>
                {
                    b.HasOne("NetCore.Data.Entities.User", "User")
                        .WithMany("AuditLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Category", b =>
                {
                    b.HasOne("NetCore.Data.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Invoice", b =>
                {
                    b.HasOne("NetCore.Data.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("NetCore.Data.Entities.Product", "Product")
                        .WithMany("Invoices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("NetCore.Data.Entities.User", "User")
                        .WithMany("Invoices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Product", b =>
                {
                    b.HasOne("NetCore.Data.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("NetCore.Data.Entities.ProductInCategory", b =>
                {
                    b.HasOne("NetCore.Data.Entities.Category", "Category")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("NetCore.Data.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("NetCore.Data.Entities.Product", "Product")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Creator");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NetCore.Data.Entities.User", b =>
                {
                    b.HasOne("NetCore.Data.Entities.User", "Creator")
                        .WithMany("CreateItems")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Category", b =>
                {
                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("NetCore.Data.Entities.Product", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("NetCore.Data.Entities.User", b =>
                {
                    b.Navigation("AuditLogs");

                    b.Navigation("CreateItems");

                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}