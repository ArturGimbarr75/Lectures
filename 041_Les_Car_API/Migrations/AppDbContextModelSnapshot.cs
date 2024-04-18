﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _041_Les_Car_API.Repositories.EF;

#nullable disable

namespace _041_Les_Car_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("_041_Les_Car_API.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("JwtToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("_041_Les_Car_API.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11bb9702-f64c-4e69-a8f0-3d6b0ff8f206"),
                            Color = "Red",
                            Make = "Toyota",
                            Model = "Corolla",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("93f8011a-868f-415b-b1c4-be06fab4d484"),
                            Color = "Blue",
                            Make = "Ford",
                            Model = "Fusion",
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("788fb6a4-0a20-492e-8a6b-96aafddd9082"),
                            Color = "Green",
                            Make = "Honda",
                            Model = "Civic",
                            Year = 2018
                        });
                });
#pragma warning restore 612, 618
        }
    }
}