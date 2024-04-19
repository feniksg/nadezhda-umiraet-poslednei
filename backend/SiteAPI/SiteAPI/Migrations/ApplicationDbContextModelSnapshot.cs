﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteAPI.Data;

#nullable disable

namespace SiteAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("SiteAPI.Models.Artwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageFilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LifePeriodId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Series")
                        .HasColumnType("TEXT");

                    b.Property<int>("YearCreated")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LifePeriodId");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("SiteAPI.Models.CustomUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CustomUsers");
                });

            modelBuilder.Entity("SiteAPI.Models.Documentation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Documentations");
                });

            modelBuilder.Entity("SiteAPI.Models.EventInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventDates")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFree")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Organizer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SiteAPI.Models.LifePeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LifePeriods");
                });

            modelBuilder.Entity("SiteAPI.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Information")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("SiteAPI.Models.Artwork", b =>
                {
                    b.HasOne("SiteAPI.Models.LifePeriod", "LifePeriod")
                        .WithMany("Artworks")
                        .HasForeignKey("LifePeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LifePeriod");
                });

            modelBuilder.Entity("SiteAPI.Models.LifePeriod", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
