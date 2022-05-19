﻿// <auto-generated />
using System;
using EFCore2DBFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore2DBFirst.Migrations
{
    [DbContext(typeof(helloappContext))]
    [Migration("20220519100556_test_one")]
    partial class test_one
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("EFCore2DBFirst.ColorReferenceBook", b =>
                {
                    b.Property<int>("ColorNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorValue")
                        .HasColumnType("INTEGER");

                    b.HasKey("ColorNumber");

                    b.ToTable("Colours");

                    b.HasCheckConstraint("ColorValue", "ColorValue > 0 AND ColorValue < 567675");
                });

            modelBuilder.Entity("EFCore2DBFirst.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JuridicalName")
                        .HasColumnType("TEXT")
                        .HasColumnName("juriName");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EFCore2DBFirst.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("EFCore2DBFirst.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMarried")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex(new[] { "Name" }, "User_name_index");

                    b.ToTable("Users");

                    b.HasCheckConstraint("Age", "Age > 0 AND Age < 120");
                });

            modelBuilder.Entity("EFCore2DBFirst.Company", b =>
                {
                    b.HasOne("EFCore2DBFirst.Country", "Country")
                        .WithMany("Companies")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EFCore2DBFirst.User", b =>
                {
                    b.HasOne("EFCore2DBFirst.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("EFCore2DBFirst.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EFCore2DBFirst.Country", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
