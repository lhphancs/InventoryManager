﻿// <auto-generated />
using System;
using Inventory.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventory.Api.Migrations
{
    [DbContext(typeof(InventoryContext))]
    partial class InventoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Inventory.Api.Aggregates.Product", b =>
                {
                    b.Property<string>("Upc")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte[]>("ShelfLocationId")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Upc");

                    b.HasIndex("ShelfLocationId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Shelf.Shelf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shelf");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Shelf.ShelfLocation", b =>
                {
                    b.Property<byte[]>("Id")
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShelfLocation");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Product", b =>
                {
                    b.HasOne("Inventory.Api.Aggregates.Shelf.ShelfLocation", "ShelfLocation")
                        .WithOne()
                        .HasForeignKey("Inventory.Api.Aggregates.Product", "ShelfLocationId");

                    b.OwnsOne("Inventory.Api.Aggregates.ProductInfo", "ProductInfo", b1 =>
                        {
                            b1.Property<string>("ProductUpc")
                                .HasColumnType("varchar(767)");

                            b1.Property<string>("Brand")
                                .HasColumnType("text");

                            b1.Property<string>("Description")
                                .HasColumnType("text");

                            b1.Property<string>("ExpirationLocation")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<int>("OunceWeight")
                                .HasColumnType("int");

                            b1.HasKey("ProductUpc");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductUpc");
                        });

                    b.OwnsOne("Inventory.Api.Aggregates.ProductPreparationInfo", "ProductPreparationInfo", b1 =>
                        {
                            b1.Property<string>("ProductUpc")
                                .HasColumnType("varchar(767)");

                            b1.Property<bool>("RequiresBox")
                                .HasColumnType("bit");

                            b1.Property<bool>("RequiresBubbleWrap")
                                .HasColumnType("bit");

                            b1.Property<bool>("RequiresPadding")
                                .HasColumnType("bit");

                            b1.HasKey("ProductUpc");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductUpc");
                        });
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Shelf.ShelfLocation", b =>
                {
                    b.HasOne("Inventory.Api.Aggregates.Shelf.Shelf", null)
                        .WithMany("ShelfLocations")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
