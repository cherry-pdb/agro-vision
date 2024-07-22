﻿// <auto-generated />
using System;
using AgroVision.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgroVision.Database.Context.Migrations
{
    [DbContext(typeof(AgroVisionContext))]
    partial class AgroVisionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AgroVision.Database.Models.AgrochemicalСharacteristicsDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("GrainYield")
                        .HasColumnType("double precision");

                    b.Property<double>("Humus")
                        .HasColumnType("double precision");

                    b.Property<double>("MobileKalium")
                        .HasColumnType("double precision");

                    b.Property<double>("MobilePhosphorus")
                        .HasColumnType("double precision");

                    b.Property<double>("OpenGroundVegetablesYield")
                        .HasColumnType("double precision");

                    b.Property<double>("PotatoYield")
                        .HasColumnType("double precision");

                    b.Property<double>("SaltExtract")
                        .HasColumnType("double precision");

                    b.Property<string>("SoilGradation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Srup")
                        .HasColumnType("double precision");

                    b.Property<double>("SunflowerYield")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("AgrochemicalСharacteristics");
                });

            modelBuilder.Entity("AgroVision.Database.Models.UserDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
