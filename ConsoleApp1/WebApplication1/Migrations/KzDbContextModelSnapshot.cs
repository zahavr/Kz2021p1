﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.EfStuff;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(KzDbContext))]
    partial class KzDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.EfStuff.Model.Adress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FloorCount")
                        .HasColumnType("int");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("WebApplication1.EfStuff.Model.Citizen", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatingDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("HouseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Citizens");
                });

            modelBuilder.Entity("WebApplication1.EfStuff.Model.SportComplex", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountOfEmployees")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SportComplex");
                });

            modelBuilder.Entity("WebApplication1.EfStuff.Model.SportEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SportEvent");
                });

            modelBuilder.Entity("WebApplication1.EfStuff.Model.SportSection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SportComplexId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SportComplexId");

                    b.ToTable("SportSection");
                });

            modelBuilder.Entity("WebApplication1.EfStuff.Model.Citizen", b =>
                {
                    b.HasOne("WebApplication1.EfStuff.Model.Adress", "House")
                        .WithMany("Citizens")
                        .HasForeignKey("HouseId");

                    b.Navigation("House");
                });

            modelBuilder.Entity("WebApplication1.EfStuff.Model.SportSection", b =>
                {
                    b.HasOne("WebApplication1.EfStuff.Model.SportComplex", null)
                        .WithMany("Sections")
                        .HasForeignKey("SportComplexId");
                });

            modelBuilder.Entity("WebApplication1.EfStuff.Model.Adress", b =>
                {
                    b.Navigation("Citizens");
                });

            modelBuilder.Entity("WebApplication1.EfStuff.Model.SportComplex", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
