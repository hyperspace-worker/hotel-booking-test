﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Data.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Data.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a5a2b423-e5af-42cc-8853-473f78843b00"),
                            Description = "You will be satisfied at 5 stars!",
                            Name = "Hotel 512"
                        },
                        new
                        {
                            Id = new Guid("ee9a26df-5a6e-4c44-be63-79adb3477aa4"),
                            Description = "Someone will roll on your bones...",
                            Name = "Small Room From Baba Yaga"
                        },
                        new
                        {
                            Id = new Guid("bd9c033c-6829-4afd-a186-584ab3599284"),
                            Description = "Just simple hotel, nothing to say",
                            Name = "Hotel ***"
                        },
                        new
                        {
                            Id = new Guid("959ccd09-7787-475f-9e9c-1c50432bff18"),
                            Description = "Oh my god, so sweet (^-^)",
                            Name = "Your mom's Room"
                        });
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6bb6c848-f57b-4e77-ae77-d8e95745469b"),
                            Email = "eg0rka@gmail.com",
                            FirstName = "Egor",
                            LastName = "Bezmenov"
                        },
                        new
                        {
                            Id = new Guid("3809b0ec-d9fb-4d77-b4ac-b68b61a9d92b"),
                            Email = "ramza@egypt.com",
                            FirstName = "Ramzes",
                            LastName = "II"
                        },
                        new
                        {
                            Id = new Guid("bead2185-f206-48b8-92d0-904f7ff0e953"),
                            Email = "kabannder@yahoo.com",
                            FirstName = "Ermolay",
                            LastName = "Kabanov"
                        },
                        new
                        {
                            Id = new Guid("060a369a-aa6f-4a3a-9bcc-ab7c53ae3051"),
                            Email = "barbara.grinder@outlook.com",
                            FirstName = "Barbara",
                            LastName = "Grinder"
                        });
                });

            modelBuilder.Entity("Data.Entities.Booking", b =>
                {
                    b.HasOne("Data.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Room", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
