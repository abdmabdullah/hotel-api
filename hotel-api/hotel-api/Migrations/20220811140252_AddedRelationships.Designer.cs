﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using hotel_api.Utilities;

#nullable disable

namespace hotel_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220811140252_AddedRelationships")]
    partial class AddedRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FacilityHotel", b =>
                {
                    b.Property<int>("FacilitiesId")
                        .HasColumnType("integer");

                    b.Property<int>("HotelsId")
                        .HasColumnType("integer");

                    b.HasKey("FacilitiesId", "HotelsId");

                    b.HasIndex("HotelsId");

                    b.ToTable("FacilityHotel");
                });

            modelBuilder.Entity("hotel_api.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int?>("HotelId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("hotel_api.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("hotel_api.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("RatePerNight")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("hotel_api.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ReviewBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReviewerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Stars")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("hotel_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("HotelReview", b =>
                {
                    b.Property<int>("HotelsId")
                        .HasColumnType("integer");

                    b.Property<int>("ReviewsId")
                        .HasColumnType("integer");

                    b.HasKey("HotelsId", "ReviewsId");

                    b.HasIndex("ReviewsId");

                    b.ToTable("HotelReview");
                });

            modelBuilder.Entity("FacilityHotel", b =>
                {
                    b.HasOne("hotel_api.Models.Facility", null)
                        .WithMany()
                        .HasForeignKey("FacilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hotel_api.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hotel_api.Models.Booking", b =>
                {
                    b.HasOne("hotel_api.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

                    b.HasOne("hotel_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelReview", b =>
                {
                    b.HasOne("hotel_api.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hotel_api.Models.Review", null)
                        .WithMany()
                        .HasForeignKey("ReviewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
