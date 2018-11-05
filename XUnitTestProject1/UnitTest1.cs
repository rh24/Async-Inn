using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace AsyncInnTest
{
    public class AsyncInnTest
    {
        /// <summary>
        /// Test getting props of amenity object
        /// </summary>
        [Fact]
        public void CanGetAmenityName()
        {
            Amenity amenity = new Amenity() { Name = "Rooftop bar" };
            Assert.Equal("Rooftop bar", amenity.Name);
        }

        /// <summary>
        /// Test setting props of amenity object
        /// </summary>
        [Fact]
        public void CanSetAmenityName()
        {
            Amenity amenity = new Amenity() { Name = "Rooftop bar" };
            string originalName = amenity.Name;
            amenity.Name = "Rainforest showerhead";
            bool sameName = originalName == amenity.Name;

            Assert.False(sameName);
            Assert.Equal("Rainforest showerhead", amenity.Name);
        }

        /// <summary>
        /// Test CRUD operations on Amenity table
        /// </summary>
        [Fact]
        public async void CreateAmenitiesDbContext()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("Amenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // CREATE
                Amenity amenity = new Amenity() { Name = "Fake snow machine" };

                context.Add(amenity);
                context.SaveChanges();

                // READ
                var foundAmenity = await context.Amenity.FirstOrDefaultAsync(am => am.Name == amenity.Name);

                Assert.Equal("Fake snow machine", foundAmenity.Name);

                // UPDATE
                foundAmenity.Name = "Robert Frost";
                context.Amenity.Update(foundAmenity);
                context.SaveChanges();

                var changedAmenity = await context.Amenity.FirstOrDefaultAsync(am => am.Name == foundAmenity.Name);

                Assert.Equal("Robert Frost", changedAmenity.Name);

                // DELETE
                context.Amenity.Remove(changedAmenity);
                context.SaveChanges();

                var deletedAmenity = context.Amenity.FirstOrDefaultAsync(am => am.Name == changedAmenity.Name);

                Assert.Null(deletedAmenity);
            }
        }

        /// <summary>
        /// Test getting props of room object
        /// </summary>
        [Fact]
        public void CanGetRoomProps()
        {
            Room room = new Room() { Name = "Room 1", Layout = Layout.OneBedroom };
            Assert.Equal("Room 1", room.Name);
            Assert.Equal(Layout.OneBedroom, room.Layout);
        }

        /// <summary>
        /// Test setting props of room object
        /// </summary>
        [Fact]
        public void CanSetRoomProps()
        {
            Room room = new Room() { Name = "Room 1", Layout = Layout.OneBedroom };
            string originalName = room.Name;
            Layout originalLayout = room.Layout;
            room.Name = "Red room";
            room.Layout = Layout.Penthouse;
            bool sameName = originalName == room.Name;
            bool sameLayout = originalLayout == room.Layout;

            Assert.False(sameName);
            Assert.False(sameLayout);
            Assert.Equal("Red room", room.Name);
            Assert.Equal(Layout.Penthouse, room.Layout);
        }

        /// <summary>
        /// Test CRUD operations on Room table
        /// </summary>
        [Fact]
        public async void CRUDRoomDbContext()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("Room").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // CREATE
                Room room = new Room() { Name = "Penthouse", Layout = Layout.Penthouse };

                context.Add(room);
                context.SaveChanges();

                // READ
                var foundRoom = await context.Rooms.FirstOrDefaultAsync(r => r.Name == room.Name);

                Assert.Equal("Penthouse", foundRoom.Name);

                // UPDATE
                foundRoom.Name = "Basement";
                context.Rooms.Update(foundRoom);
                context.SaveChanges();

                var changedRoom = await context.Amenity.FirstOrDefaultAsync(r => r.Name == foundRoom.Name);

                Assert.Equal("Basement", changedRoom.Name);

                // DELETE
                context.Amenity.Remove(changedRoom);
                context.SaveChanges();

                var deletedRoom = context.Rooms.FirstOrDefaultAsync(r => r.Name == changedRoom.Name);

                Assert.Null(deletedRoom);
            }
        }

        /// <summary>
        /// Test getting and setting props of RoomAmenities object
        /// </summary>
        [Fact]
        public void CanGetandSetRoomAmenity()
        {
            RoomAmenities ra = new RoomAmenities() { RoomID = 1, AmenityID = 2 };

            Assert.Equal(1, ra.RoomID);
            Assert.Equal(2, ra.AmenityID);

            ra.RoomID = 3;
            ra.AmenityID = 4;

            Assert.Equal(3, ra.RoomID);
            Assert.Equal(4, ra.AmenityID);
        }

        /// <summary>
        /// Test CRUD operations on RoomAmenities table
        /// </summary>
        [Fact]
        public async void CRUDRoomAmenitiesDbContext()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("RoomAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // CREATE
                RoomAmenities roomAm = new RoomAmenities() { RoomID = 1, AmenityID = 1 };

                context.Add(roomAm);
                context.SaveChanges();

                // READ
                var foundRoomAmenity = await context.RoomAmenities.FirstOrDefaultAsync(ra => ra.RoomID == roomAm.RoomID && ra.AmenityID == roomAm.AmenityID);

                Assert.Equal(1, foundRoomAmenity.RoomID);

                // UPDATE
                foundRoomAmenity.RoomID = 3;
                context.RoomAmenities.Update(foundRoomAmenity);
                context.SaveChanges();

                var changedRoomAm = await context.RoomAmenities.FirstOrDefaultAsync(ra => ra.RoomID == roomAm.RoomID && ra.AmenityID == roomAm.AmenityID);

                Assert.Equal(3, changedRoomAm.RoomID);

                // DELETE
                context.RoomAmenities.Remove(changedRoomAm);
                context.SaveChanges();

                var deletedRoom = context.RoomAmenities.FirstOrDefaultAsync(ra => ra.RoomID == roomAm.RoomID && ra.AmenityID == roomAm.AmenityID);

                Assert.Null(deletedRoom);
            }
        }

        /// <summary>
        /// Test getting and setting propes of HotelRooms object
        /// </summary>
        [Fact]
        public void CanGetAndSetHotelRooms()
        {
            HotelRooms hr = new HotelRooms() { HotelID = 1, RoomID = 2, Rate = 1000, PetFriendly = true, RoomNumber = 20 };

            Assert.Equal(1, hr.HotelID);
            Assert.Equal(2, hr.RoomID);
            Assert.Equal(1000, hr.Rate);
            Assert.True(hr.PetFriendly);
            Assert.Equal(20, hr.RoomNumber);

            hr.HotelID = 3;
            hr.RoomID = 5;
            hr.Rate = 100;
            hr.PetFriendly = false;
            hr.RoomNumber = 10;

            Assert.Equal(3, hr.HotelID);
            Assert.Equal(5, hr.RoomID);
            Assert.Equal(100, hr.Rate);
            Assert.False(hr.PetFriendly);
            Assert.Equal(10, hr.RoomNumber);
        }

        /// <summary>
        /// Test CRUD operations on HotelRooms table
        /// </summary>
        [Fact]
        public async void CRUDHotelRoomsDbContext()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("HotelRooms").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // CREATE
                HotelRooms hotelRoom = new HotelRooms() { RoomID = 1, HotelID = 1, PetFriendly = true, Rate = 1000, RoomNumber = 401 };

                context.Add(hotelRoom);
                context.SaveChanges();

                // READ
                var foundHotelRoom = await context.HotelRooms.FirstOrDefaultAsync(hr => hr.RoomID == hotelRoom.RoomID && hr.HotelID == hotelRoom.HotelID);

                Assert.Equal(1, foundHotelRoom.RoomID);

                // UPDATE
                foundHotelRoom.RoomID = 3;
                context.HotelRooms.Update(foundHotelRoom);
                context.SaveChanges();

                var changedHotelRoom = await context.HotelRooms.FirstOrDefaultAsync(hr => hr.RoomID == hotelRoom.RoomID && hr.HotelID == hotelRoom.HotelID);

                Assert.Equal(3, changedHotelRoom.RoomID);

                // DELETE
                context.HotelRooms.Remove(changedHotelRoom);
                context.SaveChanges();

                var deletedRoom = context.HotelRooms.FirstOrDefaultAsync(hr => hr.RoomID == hotelRoom.RoomID && hr.HotelID == hotelRoom.HotelID);

                Assert.Null(deletedRoom);
            }
        }

        /// <summary>
        /// Test getting and setting props of Hotel object
        /// </summary>
        [Fact]
        public void CanGetAndSetHotel()
        {
            Hotel hotel = new Hotel() { Name = "The Async Inn", Address = "123 Merry Lane", Phone = "2228887777" };

            Assert.Equal("The Async Inn", hotel.Name);
            Assert.Equal("123 Merry Lane", hotel.Address);
            Assert.Equal("2228887777", hotel.Phone);

            hotel.Name = "Fake hotel";
            hotel.Address = "test";
            hotel.Phone = "test string";

            Assert.Equal("Fake hotel", hotel.Name);
            Assert.Equal("test", hotel.Address);
            Assert.Equal("test string", hotel.Phone);
        }

        /// <summary>
        /// Test CRUD operations on Hotel table
        /// </summary>
        [Fact]
        public async void CRUDHotelDbContext()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("Room").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // CREATE
                Hotel hotel = new Hotel() { Name = "Andaz", Address = "1 Bay Rd", Phone = "1112223333" };

                context.Add(hotel);
                context.SaveChanges();

                // READ
                var foundHotel = await context.Hotels.FirstOrDefaultAsync(h => h.ID == hotel.ID);

                Assert.Equal("Andaz", foundHotel.Name);

                // UPDATE
                foundHotel.Name = "Hyatt";
                context.Hotels.Update(foundHotel);
                context.SaveChanges();

                var changedHotel = await context.Hotels.FirstOrDefaultAsync(h => h.ID == foundHotel.ID);

                Assert.Equal("Hyatt", changedHotel.Name);

                // DELETE
                context.Hotels.Remove(changedHotel);
                context.SaveChanges();

                var deletedHotel = context.Rooms.FirstOrDefaultAsync(h => h.ID == changedHotel.ID);

                Assert.Null(deletedHotel);
            }
        }
    }
}