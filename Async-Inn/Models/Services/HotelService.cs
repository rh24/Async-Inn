using AsyncInn.Data;
using AsyncInn.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotel
    {
        // private backing field to set the dependency
        private AsyncInnDbContext _context;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context">Constructor dependency injection</param>
        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Implement CREATE method that adds a newly created hotel to the database.
        /// </summary>
        /// <param name="hotel">Hotel object to add to db</param>
        /// <returns>Task has no return value</returns>
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Implement a READ method that grabs an hotel object from the database by ID.
        /// </summary>
        /// <param name="id">ID of hotel object to grab</param>
        /// <returns>Hotel object</returns>
        public async Task<Hotel> GetHotel(int? id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(a => a.ID == id);
        }

        /// <summary>
        /// Implement a READ method that grabs all the amenities in the database.
        /// </summary>
        /// <returns>An IEnumerable collection of Amenity objects</returns>
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        /// <summary>
        /// Implement an UPDATE method that updates the information of an hotel in the database.
        /// </summary>
        /// <param name="hotel">Hotel object with the new info</param>
        /// <returns>Task has no return value</returns>
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Implement an DELETE method that deletes an hotel by ID from the database.
        /// </summary>
        /// <param name="hotel">ID of Hotel object to delete</param>
        /// <returns>Task has no return value</returns>
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
