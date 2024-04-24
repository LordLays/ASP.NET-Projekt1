﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(TravelAgencyContext))]
    partial class TravelAgencyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelRoomReservation", b =>
                {
                    b.Property<long>("BookedRoomsIDHotelRoom")
                        .HasColumnType("bigint");

                    b.Property<long>("ReservationsIDReservation")
                        .HasColumnType("bigint");

                    b.HasKey("BookedRoomsIDHotelRoom", "ReservationsIDReservation");

                    b.HasIndex("ReservationsIDReservation");

                    b.ToTable("HotelRoomReservation");
                });

            modelBuilder.Entity("OfertTag", b =>
                {
                    b.Property<long>("HotelsIDOfert")
                        .HasColumnType("bigint");

                    b.Property<long>("TagsIDTag")
                        .HasColumnType("bigint");

                    b.HasKey("HotelsIDOfert", "TagsIDTag");

                    b.HasIndex("TagsIDTag");

                    b.ToTable("OfertTag");
                });

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.Property<long>("IDCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDCustomer"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDCustomer");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApplication1.Models.Hotel", b =>
                {
                    b.Property<long>("IDHotel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDHotel"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("AverageCustomersRating")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.HasKey("IDHotel");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("WebApplication1.Models.HotelRoom", b =>
                {
                    b.Property<long>("IDHotelRoom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDHotelRoom"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<long>("Capacity")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long>("HotelID")
                        .HasColumnType("bigint");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDHotelRoom");

                    b.HasIndex("HotelID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("WebApplication1.Models.Ofert", b =>
                {
                    b.Property<long>("IDOfert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDOfert"));

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("HotelID")
                        .HasColumnType("bigint");

                    b.Property<int>("Meal")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TakeOffPlace")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TripType")
                        .HasColumnType("int");

                    b.HasKey("IDOfert");

                    b.HasIndex("HotelID");

                    b.ToTable("Oferts");
                });

            modelBuilder.Entity("WebApplication1.Models.Reservation", b =>
                {
                    b.Property<long>("IDReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDReservation"));

                    b.Property<long>("CustomerID")
                        .HasColumnType("bigint");

                    b.Property<long>("OfertID")
                        .HasColumnType("bigint");

                    b.HasKey("IDReservation");

                    b.HasIndex("CustomerID");

                    b.HasIndex("OfertID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("WebApplication1.Models.Review", b =>
                {
                    b.Property<long>("IDReview")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDReview"));

                    b.Property<long>("CustomerID")
                        .HasColumnType("bigint");

                    b.Property<long>("HotelID")
                        .HasColumnType("bigint");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Reviews")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("IDReview");

                    b.HasIndex("CustomerID");

                    b.HasIndex("HotelID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebApplication1.Models.Tag", b =>
                {
                    b.Property<long>("IDTag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDTag"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDTag");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("HotelRoomReservation", b =>
                {
                    b.HasOne("WebApplication1.Models.HotelRoom", null)
                        .WithMany()
                        .HasForeignKey("BookedRoomsIDHotelRoom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationsIDReservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OfertTag", b =>
                {
                    b.HasOne("WebApplication1.Models.Ofert", null)
                        .WithMany()
                        .HasForeignKey("HotelsIDOfert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsIDTag")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.HotelRoom", b =>
                {
                    b.HasOne("WebApplication1.Models.Hotel", "Hotel")
                        .WithMany("RoomList")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("WebApplication1.Models.Ofert", b =>
                {
                    b.HasOne("WebApplication1.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelID");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("WebApplication1.Models.Reservation", b =>
                {
                    b.HasOne("WebApplication1.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Ofert", "Ofert")
                        .WithMany()
                        .HasForeignKey("OfertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Ofert");
                });

            modelBuilder.Entity("WebApplication1.Models.Review", b =>
                {
                    b.HasOne("WebApplication1.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("WebApplication1.Models.Hotel", b =>
                {
                    b.Navigation("RoomList");
                });
#pragma warning restore 612, 618
        }
    }
}
