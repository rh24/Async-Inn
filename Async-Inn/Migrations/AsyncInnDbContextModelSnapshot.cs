﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Amenity");

                    b.HasData(
                        new { ID = 1, Name = "Coffee maker" },
                        new { ID = 2, Name = "Waterfront view" },
                        new { ID = 3, Name = "Netflix" },
                        new { ID = 4, Name = "Luxury minibar" },
                        new { ID = 5, Name = "Private pianist" },
                        new { ID = 6, Name = "Browse unpublished letters by Ernest Hemingway" },
                        new { ID = 7, Name = "Floating brunch" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new { ID = 1, Address = "49-27 219th St", Name = "The Async Inn - Queens", Phone = "718-884-5535" },
                        new { ID = 2, Address = "510 Madison Ave", Name = "The Async Inn - Manhattan", Phone = "718-347-0990" },
                        new { ID = 3, Address = "1080 Altantic Ave", Name = "The Async Inn - Brooklyn", Phone = "347-888-8878" },
                        new { ID = 4, Address = "4 Fairview Rd", Name = "The Async Inn - Staten Island", Phone = "917-888-8878" },
                        new { ID = 5, Address = "210 Dreiser Loop", Name = "The Async Inn - Bronx", Phone = "718-616-3376" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRooms", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomID");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomNumber");

                    b.HasKey("HotelID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new { ID = 1, Layout = 1, Name = "Winter Retreat" },
                        new { ID = 2, Layout = 3, Name = "Amazonian River" },
                        new { ID = 3, Layout = 0, Name = "Sunset Park" },
                        new { ID = 4, Layout = 2, Name = "Himalayan Mountain" },
                        new { ID = 5, Layout = 1, Name = "The Matrix" },
                        new { ID = 6, Layout = 0, Name = "Esoteric Sunrise" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomID");

                    b.Property<int>("AmenityID");

                    b.HasKey("RoomID", "AmenityID");

                    b.HasIndex("AmenityID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRooms", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
