using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class RoomService : IRoom
    {
        // private backing field to set the dependency
        private AsyncInnDbContext _context;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context">Constructor dependency injection</param>
        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Implement CREATE method that adds a newly created room to the database.
        /// </summary>
        /// <param name="room">Room object to add to db</param>
        /// <returns>Task has no return value</returns>
        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Implement a READ method that grabs an room object from the database by ID.
        /// </summary>
        /// <param name="id">ID of room object to grab</param>
        /// <returns>Room object</returns>
        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(a => a.ID == id);
        }

        /// <summary>
        /// Implement a READ method that grabs all the rooms in the database.
        /// </summary>
        /// <returns>An IEnumerable collection of Room objects</returns>
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        /// <summary>
        /// Implement an UPDATE method that updates the information of an room in the database.
        /// </summary>
        /// <param name="room">Amenity object with the new info</param>
        /// <returns>Task has no return value</returns>
        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Implement an DELETE method that deletes an room by ID from the database.
        /// </summary>
        /// <param name="room">ID of Room object to delete</param>
        /// <returns>Task has no return value</returns>
        public async Task DeleteRoom(int id)
        {
            Room room = await GetRoom(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
