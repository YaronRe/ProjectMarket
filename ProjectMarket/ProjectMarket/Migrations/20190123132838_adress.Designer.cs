﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectMarket.Models;

namespace ProjectMarket.Migrations
{
    [DbContext(typeof(ProjectMarketContext))]
    [Migration("20190123132838_adress")]
    partial class adress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectMarket.Models.AcademicInstitute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("AcademicInstitute");

                    b.HasData(
                        new { Id = 1, Name = "המכללה למנהל" },
                        new { Id = 2, Name = "מכון לב" }
                    );
                });

            modelBuilder.Entity("ProjectMarket.Models.FieldOfStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("FieldOfStudy");

                    b.HasData(
                        new { Id = 1, Name = "מדעי המחשב" },
                        new { Id = 2, Name = "כלכלה" },
                        new { Id = 3, Name = "פיזיקה" }
                    );
                });

            modelBuilder.Entity("ProjectMarket.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicInstituteId");

                    b.Property<string>("Address")
                        .HasMaxLength(300);

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<int>("FieldOfStudyId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("OwnerId");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("AcademicInstituteId");

                    b.HasIndex("FieldOfStudyId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Project");

                    b.HasData(
                        new { Id = 1, AcademicInstituteId = 1, Address = "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל", Description = "", FieldOfStudyId = 2, IsDeleted = true, Name = "DeletedOfUser", OwnerId = 2, Price = 10.0 },
                        new { Id = 2, AcademicInstituteId = 1, Address = "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל", Description = "", FieldOfStudyId = 2, IsDeleted = true, Name = "DeletedOfDelUser", OwnerId = 6, Price = 20.0 },
                        new { Id = 3, AcademicInstituteId = 1, Address = "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל", Description = "", FieldOfStudyId = 2, IsDeleted = false, Name = "Sold", OwnerId = 5, Price = 30.0 },
                        new { Id = 4, AcademicInstituteId = 1, Address = "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל", Description = "", FieldOfStudyId = 2, IsDeleted = false, Name = "NotSold", OwnerId = 4, Price = 40.0 },
                        new { Id = 5, AcademicInstituteId = 1, Address = "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל", Description = "", FieldOfStudyId = 2, IsDeleted = true, Name = "SoldAndDeleted", OwnerId = 4, Price = 50.0 },
                        new { Id = 6, AcademicInstituteId = 1, Address = "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל", Description = "", FieldOfStudyId = 2, IsDeleted = false, Name = "SoldMultiple", OwnerId = 4, Price = 60.0 },
                        new { Id = 7, AcademicInstituteId = 1, Address = "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל", Description = "", FieldOfStudyId = 2, IsDeleted = false, Name = "Graded", OwnerId = 4, Price = 60.0 },
                        new { Id = 8, AcademicInstituteId = 1, Address = "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל", Description = "", FieldOfStudyId = 2, IsDeleted = false, Name = "NotGraded", OwnerId = 4, Price = 60.0 }
                    );
                });

            modelBuilder.Entity("ProjectMarket.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AcademicInstituteId");

                    b.Property<bool>("AcceptedByBuyer");

                    b.Property<bool>("AcceptedBySeller");

                    b.Property<int>("BuyerId");

                    b.Property<int?>("Grade");

                    b.Property<double>("Price");

                    b.Property<int>("ProjectId");

                    b.Property<int?>("Rank");

                    b.HasKey("Id");

                    b.HasIndex("AcademicInstituteId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Sale");

                    b.HasData(
                        new { Id = 1, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 1, Price = 0.0, ProjectId = 3 },
                        new { Id = 2, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 1, Price = 0.0, ProjectId = 4 },
                        new { Id = 3, AcademicInstituteId = 1, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 1, Grade = 70, Price = 0.0, ProjectId = 6, Rank = 2 },
                        new { Id = 5, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 3, Price = 0.0, ProjectId = 3 },
                        new { Id = 6, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 3, Price = 0.0, ProjectId = 5 },
                        new { Id = 4, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 3, Price = 0.0, ProjectId = 6 },
                        new { Id = 7, AcademicInstituteId = 1, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 3, Grade = 80, Price = 0.0, ProjectId = 7, Rank = 4 },
                        new { Id = 8, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 3, Price = 0.0, ProjectId = 8 },
                        new { Id = 10, AcademicInstituteId = 2, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 5, Grade = 70, Price = 0.0, ProjectId = 3, Rank = 3 },
                        new { Id = 11, AcademicInstituteId = 2, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 5, Grade = 70, Price = 0.0, ProjectId = 5, Rank = 3 },
                        new { Id = 9, AcademicInstituteId = 2, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 5, Grade = 70, Price = 0.0, ProjectId = 6, Rank = 3 },
                        new { Id = 12, AcademicInstituteId = 2, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 6, Grade = 70, Price = 0.0, ProjectId = 3, Rank = 3 },
                        new { Id = 13, AcademicInstituteId = 2, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 6, Grade = 70, Price = 0.0, ProjectId = 5, Rank = 3 },
                        new { Id = 14, AcademicInstituteId = 2, AcceptedByBuyer = false, AcceptedBySeller = false, BuyerId = 6, Grade = 70, Price = 0.0, ProjectId = 6, Rank = 3 }
                    );
                });

            modelBuilder.Entity("ProjectMarket.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMail")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .HasMaxLength(20);

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new { Id = 1, EMail = "admin@gmail.com", FirstName = "AdminF", IsAdmin = true, IsDeleted = false, LastName = "AdminL", Password = "?X]??Q?3?p??5?*????m???\"e???	?)?? ?e(&??\\pf??<??7/??M????????", UserName = "Admin" },
                        new { Id = 2, EMail = "user@gmail.com", FirstName = "UserF", IsAdmin = false, IsDeleted = false, LastName = "UserL", Password = "?X]??Q?3?p??5?*????m???\"e???	?)?? ?e(&??\\pf??<??7/??M????????", UserName = "User" },
                        new { Id = 3, EMail = "user@gmail.com", FirstName = "UserF", IsAdmin = false, IsDeleted = false, LastName = "UserL", Password = "?X]??Q?3?p??5?*????m???\"e???	?)?? ?e(&??\\pf??<??7/??M????????", UserName = "Buyer" },
                        new { Id = 4, EMail = "user@gmail.com", FirstName = "UserF", IsAdmin = false, IsDeleted = false, LastName = "UserL", Password = "?X]??Q?3?p??5?*????m???\"e???	?)?? ?e(&??\\pf??<??7/??M????????", UserName = "Seller" },
                        new { Id = 5, EMail = "user@gmail.com", FirstName = "UserF", IsAdmin = false, IsDeleted = false, LastName = "UserL", Password = "?X]??Q?3?p??5?*????m???\"e???	?)?? ?e(&??\\pf??<??7/??M????????", UserName = "BuyerSeller" },
                        new { Id = 6, EMail = "user@gmail.com", FirstName = "UserF", IsAdmin = false, IsDeleted = true, LastName = "UserL", Password = "?X]??Q?3?p??5?*????m???\"e???	?)?? ?e(&??\\pf??<??7/??M????????", UserName = "deleted" },
                        new { Id = 7, EMail = "user@gmail.com", FirstName = "UserF", IsAdmin = false, IsDeleted = false, LastName = "UserL", Password = "?X]??Q?3?p??5?*????m???\"e???	?)?? ?e(&??\\pf??<??7/??M????????", UserName = "Grader" }
                    );
                });

            modelBuilder.Entity("ProjectMarket.Models.Project", b =>
                {
                    b.HasOne("ProjectMarket.Models.AcademicInstitute", "AcademicInstitute")
                        .WithMany()
                        .HasForeignKey("AcademicInstituteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectMarket.Models.FieldOfStudy", "FieldOfStudy")
                        .WithMany()
                        .HasForeignKey("FieldOfStudyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectMarket.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ProjectMarket.Models.Sale", b =>
                {
                    b.HasOne("ProjectMarket.Models.AcademicInstitute", "AcademicInstitute")
                        .WithMany()
                        .HasForeignKey("AcademicInstituteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectMarket.Models.User", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectMarket.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
