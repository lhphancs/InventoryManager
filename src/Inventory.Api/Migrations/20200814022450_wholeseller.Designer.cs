﻿// <auto-generated />
using System;
using Inventory.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventory.Api.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20200814022450_wholeseller")]
    partial class wholeseller
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Inventory.Api.Aggregates.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Upc")
                        .HasColumnType("varchar(767)");

                    b.Property<int?>("WholesalerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShelfLocationId")
                        .IsUnique();

                    b.HasIndex("Upc")
                        .IsUnique();

                    b.HasIndex("WholesalerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Shelf.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shelfs");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Shelf.ShelfLocation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShelfLocation");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Wholesaler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");
                });

            modelBuilder.Entity("Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses.ProductWholesaler", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("WholesalerId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "WholesalerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("ProductWholesaler");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Product", b =>
                {
                    b.HasOne("Inventory.Api.Aggregates.Shelf.ShelfLocation", "ShelfLocation")
                        .WithOne()
                        .HasForeignKey("Inventory.Api.Aggregates.Product", "ShelfLocationId");

                    b.HasOne("Inventory.Api.Aggregates.Wholesaler", null)
                        .WithMany("Products")
                        .HasForeignKey("WholesalerId");

                    b.OwnsOne("Inventory.Api.ValueObjects.ProductInfo", "ProductInfo", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

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

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Inventory.Api.ValueObjects.ProductPreparationInfo", "ProductPreparationInfo", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<bool>("RequiresBox")
                                .HasColumnType("bit");

                            b1.Property<bool>("RequiresBubbleWrap")
                                .HasColumnType("bit");

                            b1.Property<bool>("RequiresPadding")
                                .HasColumnType("bit");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
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

            modelBuilder.Entity("Inventory.Api.Aggregates.Wholesaler", b =>
                {
                    b.OwnsOne("Inventory.Api.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("WholesalerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.HasKey("WholesalerId");

                            b1.ToTable("Wholesalers");

                            b1.WithOwner()
                                .HasForeignKey("WholesalerId");
                        });
                });

            modelBuilder.Entity("Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses.ProductWholesaler", b =>
                {
                    b.HasOne("Inventory.Api.Aggregates.Product", "Product")
                        .WithMany("ProductWholesalers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Api.Aggregates.Wholesaler", "Wholesaler")
                        .WithMany("ProductWholesalers")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
