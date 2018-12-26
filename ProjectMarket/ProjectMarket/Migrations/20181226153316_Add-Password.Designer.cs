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
    [Migration("20181226153316_Add-Password")]
    partial class AddPassword
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
                });

            modelBuilder.Entity("ProjectMarket.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AcademicInstituteId");

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<int?>("FieldOfStudyId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("AcademicInstituteId");

                    b.HasIndex("FieldOfStudyId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ProjectMarket.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AcademicInstituteId");

                    b.Property<int?>("BuyerId");

                    b.Property<double>("MeetingLocationX");

                    b.Property<double>("MeetingLocationY");

                    b.Property<double>("Price");

                    b.Property<int?>("ProjectId");

                    b.Property<int>("ProjectsGrade");

                    b.Property<int>("Rank");

                    b.HasKey("Id");

                    b.HasIndex("AcademicInstituteId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("ProjectMarket.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMail")
                        .IsRequired();

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectMarket.Models.Project", b =>
                {
                    b.HasOne("ProjectMarket.Models.AcademicInstitute", "AcademicInstitute")
                        .WithMany()
                        .HasForeignKey("AcademicInstituteId");

                    b.HasOne("ProjectMarket.Models.FieldOfStudy", "FieldOfStudy")
                        .WithMany()
                        .HasForeignKey("FieldOfStudyId");

                    b.HasOne("ProjectMarket.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("ProjectMarket.Models.Sale", b =>
                {
                    b.HasOne("ProjectMarket.Models.AcademicInstitute", "AcademicInstitute")
                        .WithMany()
                        .HasForeignKey("AcademicInstituteId");

                    b.HasOne("ProjectMarket.Models.User", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.HasOne("ProjectMarket.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
