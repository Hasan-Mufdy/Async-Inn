﻿// <auto-generated />
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Async_Inn.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20230726211917_a")]
    partial class a
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Async_Inn.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AMN_1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AMN_2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AMN_3"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Amman",
                            Name = "hotel 1",
                            Phone = "075354135",
                            State = "Amman",
                            StreetAddress = "Amman street"
                        },
                        new
                        {
                            ID = 2,
                            City = "Amman",
                            Name = "hotel 2",
                            Phone = "075354135",
                            State = "Amman",
                            StreetAddress = "Amman street"
                        },
                        new
                        {
                            ID = 3,
                            City = "Amman",
                            Name = "hotel 3",
                            Phone = "075354135",
                            State = "Amman",
                            StreetAddress = "Amman street"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenities = "AM_1",
                            Layout = 1,
                            Name = "Room 1"
                        },
                        new
                        {
                            Id = 2,
                            Amenities = "AM_2",
                            Layout = 1,
                            Name = "Room 2"
                        },
                        new
                        {
                            Id = 3,
                            Amenities = "AM_3",
                            Layout = 1,
                            Name = "Room 3"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenity", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenity", b =>
                {
                    b.HasOne("Async_Inn.Models.Amenity", null)
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Async_Inn.Models.Room", null)
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Async_Inn.Models.Amenity", b =>
                {
                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("Async_Inn.Models.Room", b =>
                {
                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
