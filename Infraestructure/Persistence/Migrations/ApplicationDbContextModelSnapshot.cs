﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccountsReceivable.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.BankAccounts.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Details")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique()
                        .HasFilter("[Number] IS NOT NULL");

                    b.ToTable("BankAccounts", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
