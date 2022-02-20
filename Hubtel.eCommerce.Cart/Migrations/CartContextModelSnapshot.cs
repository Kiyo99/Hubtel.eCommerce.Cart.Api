﻿// <auto-generated />
using System;
using Hubtel.eCommerce.Cart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hubtel.eCommerce.Cart.Migrations
{
    [DbContext(typeof(CartContext))]
    partial class CartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hubtel.eCommerce.Cart.Models.Cartt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<double>("unitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
