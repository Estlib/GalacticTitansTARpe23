﻿// <auto-generated />
using System;
using GalacticTitans.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GalacticTitans.Data.Migrations
{
    [DbContext(typeof(GalacticTitansContext))]
    partial class GalacticTitansContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GalacticTitans.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TitanID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("FilesToDatabase");
                });

            modelBuilder.Entity("GalacticTitans.Core.Domain.Titan", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrimaryAttackName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrimaryAttackPower")
                        .HasColumnType("int");

                    b.Property<string>("SecondaryAttackName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecondaryAttackPower")
                        .HasColumnType("int");

                    b.Property<string>("SpecialAttackName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialAttackPower")
                        .HasColumnType("int");

                    b.Property<DateTime>("TitanDied")
                        .HasColumnType("datetime2");

                    b.Property<int>("TitanHealth")
                        .HasColumnType("int");

                    b.Property<int>("TitanLevel")
                        .HasColumnType("int");

                    b.Property<string>("TitanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TitanStatus")
                        .HasColumnType("int");

                    b.Property<int>("TitanType")
                        .HasColumnType("int");

                    b.Property<DateTime>("TitanWasBorn")
                        .HasColumnType("datetime2");

                    b.Property<int>("TitanXP")
                        .HasColumnType("int");

                    b.Property<int>("TitanXPNextLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Titans");
                });
#pragma warning restore 612, 618
        }
    }
}
