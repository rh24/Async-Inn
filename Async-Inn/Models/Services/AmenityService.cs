using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Interfaces;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenityService : IAmenity
    {
        // private backing field to set the dependency
        private AsyncInnDbContext _context;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context">Constructor dependency injection</param>
        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Implement CREATE method that adds a newly created amenity to the database.
        /// </summary>
        /// <param name="amenity">Amenity object to add to db</param>
        /// <returns>Task has no return value</returns>
        public async Task CreateAmenity(Amenity amenity)
        {
            _context.Amenity.Add(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Implement a READ method that grabs an amenity object from the database by ID.
        /// </summary>
        /// <param name="id">ID of amenity object to grab</param>
        /// <returns>Amenity object</returns>
        public async Task<Amenity> GetAmenity(int? id)
        {
            return await _context.Amenity.FirstOrDefaultAsync(a => a.ID == id);
        }

        /// <summary>
        /// Implement a READ method that grabs all the amenities in the database.
        /// </summary>
        /// <returns>An IEnumerable collection of Amenity objects</returns>
        public async Task<IEnumerable<Amenity>> GetAmenities()
        {
            return await _context.Amenity.ToListAsync();
        }

        /// <summary>
        /// Implement an UPDATE method that updates the information of an amenity in the database.
        /// </summary>
        /// <param name="amenity">Amenity object with the new info</param>
        /// <returns>Task has no return value</returns>
        public async Task UpdateAmenity(Amenity amenity)
        {
            _context.Amenity.Update(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Implement an DELETE method that deletes an amenity by ID from the database.
        /// </summary>
        /// <param name="amenity">ID of Amenity object to delete</param>
        /// <returns>Task has no return value</returns>
        public async Task DeleteAmenity(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Amenity.Remove(amenity);
            await _context.SaveChangesAsync();
        }
    }
}
