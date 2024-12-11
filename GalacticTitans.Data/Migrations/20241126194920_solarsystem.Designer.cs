﻿// <auto-generated />
using System;
using GalacticTitans.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GalacticTitans.Data.Migrations
{
    [DbContext(typeof(GalacticTitansContext))]
    [Migration("20241126194920_solarsystem")]
    partial class solarsystem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GalacticTitans.Core.Domain.AstralBody", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AstralBodyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AstralBodyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AstralBodyType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnvironmentBoost")
                        .HasColumnType("int");

                    b.Property<int>("MajorSettlements")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SolarSystemID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TechnicalLevel")
                        .HasColumnType("int");

                    b.Property<Guid?>("TitanWhoOwnsThisPlanetID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("SolarSystemID")
                        .IsUnique()
                        .HasFilter("[SolarSystemID] IS NOT NULL");

                    b.HasIndex("TitanWhoOwnsThisPlanetID");

                    b.ToTable("AstralBodies");
                });

            modelBuilder.Entity("GalacticTitans.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AstralBodyID")
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

            modelBuilder.Entity("GalacticTitans.Core.Domain.SolarSystem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AstralBodyAtCenter")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SolarSystemLore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolarSystemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("SolarSystems");
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

            modelBuilder.Entity("GalacticTitans.Core.Domain.AstralBody", b =>
                {
                    b.HasOne("GalacticTitans.Core.Domain.SolarSystem", null)
                        .WithOne("AstralBodyAtCenterWith")
                        .HasForeignKey("GalacticTitans.Core.Domain.AstralBody", "SolarSystemID");

                    b.HasOne("GalacticTitans.Core.Domain.Titan", "TitanWhoOwnsThisPlanet")
                        .WithMany()
                        .HasForeignKey("TitanWhoOwnsThisPlanetID");

                    b.Navigation("TitanWhoOwnsThisPlanet");
                });

            modelBuilder.Entity("GalacticTitans.Core.Domain.SolarSystem", b =>
                {
                    b.Navigation("AstralBodyAtCenterWith");
                });
#pragma warning restore 612, 618
        }
    }
}
