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

        [Fact]
        public void CanGetAmenityName()
        {
            Amenity amenity = new Amenity() { Name = "Rooftop bar" };
            Assert.Equal("Rooftop bar", amenity.Name);
        }

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

        [Fact]
        public async System.Threading.Tasks.Task CreateAmenitiesDbContextAsync()
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

        [Fact]
        public void CanGetRoomProps()
        {
            Room room = new Room() { Name = "Room 1", Layout = Layout.OneBedroom };
            Assert.Equal("Room 1", room.Name);
            Assert.Equal(Layout.OneBedroom, room.Layout);
        }

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
    }
}