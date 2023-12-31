﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230830201301_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NLayer.Core.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "kitaplar",
                            createdDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Name = "defterler",
                            createdDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Name = "kalemler",
                            createdDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Name = "urun1",
                            Price = 15m,
                            Stock = 10,
                            createdDate = new DateTime(2023, 8, 30, 23, 13, 1, 696, DateTimeKind.Local).AddTicks(700)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "urun2",
                            Price = 15m,
                            Stock = 10,
                            createdDate = new DateTime(2023, 8, 30, 23, 13, 1, 696, DateTimeKind.Local).AddTicks(712)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Name = "urun3",
                            Price = 15m,
                            Stock = 10,
                            createdDate = new DateTime(2023, 8, 30, 23, 13, 1, 696, DateTimeKind.Local).AddTicks(714)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "urun4",
                            Price = 15m,
                            Stock = 10,
                            createdDate = new DateTime(2023, 8, 30, 23, 13, 1, 696, DateTimeKind.Local).AddTicks(715)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Name = "urun5",
                            Price = 15m,
                            Stock = 10,
                            createdDate = new DateTime(2023, 8, 30, 23, 13, 1, 696, DateTimeKind.Local).AddTicks(717)
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Name = "urun6",
                            Price = 15m,
                            Stock = 10,
                            createdDate = new DateTime(2023, 8, 30, 23, 13, 1, 696, DateTimeKind.Local).AddTicks(719)
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Name = "urun7",
                            Price = 15m,
                            Stock = 10,
                            createdDate = new DateTime(2023, 8, 30, 23, 13, 1, 696, DateTimeKind.Local).AddTicks(720)
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "kırmızı1",
                            Height = 100,
                            ProductId = 1,
                            Width = 10
                        },
                        new
                        {
                            Id = 2,
                            Color = "kırmızı2",
                            Height = 100,
                            ProductId = 2,
                            Width = 10
                        },
                        new
                        {
                            Id = 3,
                            Color = "kırmızı3",
                            Height = 100,
                            ProductId = 3,
                            Width = 10
                        },
                        new
                        {
                            Id = 4,
                            Color = "kırmızı4",
                            Height = 100,
                            ProductId = 4,
                            Width = 10
                        },
                        new
                        {
                            Id = 5,
                            Color = "kırmızı5",
                            Height = 100,
                            ProductId = 5,
                            Width = 10
                        },
                        new
                        {
                            Id = 6,
                            Color = "kırmızı6",
                            Height = 100,
                            ProductId = 6,
                            Width = 10
                        },
                        new
                        {
                            Id = 7,
                            Color = "kırmızı7",
                            Height = 100,
                            ProductId = 7,
                            Width = 10
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.HasOne("NLayer.Core.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NLayer.Core.Entity.ProductFeature", b =>
                {
                    b.HasOne("NLayer.Core.Entity.Product", "Product")
                        .WithOne("Feature")
                        .HasForeignKey("NLayer.Core.Entity.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NLayer.Core.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.Navigation("Feature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
