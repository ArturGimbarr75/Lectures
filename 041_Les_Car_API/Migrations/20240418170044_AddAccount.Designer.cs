﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _041_Les_Car_API.Repositories.EF;

#nullable disable

namespace _041_Les_Car_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240418170044_AddAccount")]
    partial class AddAccount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("_041_Les_Car_API.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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
                            Id = new Guid("28704f61-e4a7-4421-bfe1-60854f3c8643"),
                            Color = "Red",
                            Make = "Toyota",
                            Model = "Corolla",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("a3b17dce-2849-4b24-96a9-6ff319b58487"),
                            Color = "Blue",
                            Make = "Ford",
                            Model = "Fusion",
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("a8e362b6-2369-4a51-9422-852b0ea1ebaa"),
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
