﻿// <auto-generated />
using System;
using AppDataPribadi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppDataPribadi.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    [Migration("20241109184639_UpdateNIKColumn")]
    partial class UpdateNIKColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppDataPribadi.Models.Person", b =>
                {
                    b.Property<long>("NIK")
                        .HasColumnType("bigint");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKelamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaLengkap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Negara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TanggalLahir")
                        .HasColumnType("datetime2");

                    b.HasKey("NIK");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
