﻿using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        // For composite keys and shadow properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRooms>().HasKey(
                ce => new { ce.HotelID, ce.RoomID }
                );
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ce => new { ce.RoomID, ce.AmenityID }
                );
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HotelRooms>()
                .Property(hr => hr.RoomID)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<HotelRooms>()
                .Property(hr => hr.Rate)
                .HasColumnType("decimal(18,2)");

            // Seed model table with 5 hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "The Async Inn - Queens",
                    Address = "49-27 219th St",
                    Phone = "718-884-5535"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "The Async Inn - Manhattan",
                    Address = "510 Madison Ave",
                    Phone = "718-347-0990"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "The Async Inn - Brooklyn",
                    Address = "1080 Altantic Ave",
                    Phone = "347-888-8878"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "The Async Inn - Staten Island",
                    Address = "4 Fairview Rd",
                    Phone = "917-888-8878"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "The Async Inn - Bronx",
                    Address = "210 Dreiser Loop",
                    Phone = "718-616-3376"
                }
                );

            // Seed db with amentities
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    ID = 1,
                    Name = "Coffee maker",
                },
                new Amenity
                {
                    ID = 2,
                    Name = "Waterfront view",
                },
                new Amenity
                {
                    ID = 3,
                    Name = "Netflix",
                },
                new Amenity
                {
                    ID = 4,
                    Name = "Luxury minibar",
                },
                new Amenity
                {
                    ID = 5,
                    Name = "Private pianist",
                },
                new Amenity
                {
                    ID = 6,
                    Name = "Browse unpublished letters by Ernest Hemingway",
                },
                new Amenity
                {
                    ID = 7,
                    Name = "Floating brunch",
                }
                );

            //modelBuilder.Seed();
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRooms> HotelRooms { get; set; }
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
