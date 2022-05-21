﻿// <auto-generated />
using System;
using Cabinet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cabinet.Migrations
{
    [DbContext(typeof(CabinetContext))]
    [Migration("20220521082429_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Cabinet.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NeighborhoodId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("NeighborhoodId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NeighborhoodId1");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Cabinet.Models.Commute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CommuterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateEnder")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("TEXT");

                    b.Property<long>("DestinationId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DriverId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("OriginId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CommuterId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("DriverId");

                    b.HasIndex("OriginId");

                    b.ToTable("Commutes");
                });

            modelBuilder.Entity("Cabinet.Models.Commuter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Commuters");
                });

            modelBuilder.Entity("Cabinet.Models.Driver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Cabinet.Models.Neighborhood", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("Cabinet.Models.Address", b =>
                {
                    b.HasOne("Cabinet.Models.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("Cabinet.Models.Commute", b =>
                {
                    b.HasOne("Cabinet.Models.Commuter", "Commuter")
                        .WithMany("Commutes")
                        .HasForeignKey("CommuterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cabinet.Models.Address", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cabinet.Models.Driver", "Driver")
                        .WithMany("Commutes")
                        .HasForeignKey("DriverId");

                    b.HasOne("Cabinet.Models.Address", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commuter");

                    b.Navigation("Destination");

                    b.Navigation("Driver");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("Cabinet.Models.Commuter", b =>
                {
                    b.Navigation("Commutes");
                });

            modelBuilder.Entity("Cabinet.Models.Driver", b =>
                {
                    b.Navigation("Commutes");
                });
#pragma warning restore 612, 618
        }
    }
}
