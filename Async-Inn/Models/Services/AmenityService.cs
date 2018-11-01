using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Interfaces;
using AsyncInn.Data;

namespace AsyncInn.Models.Services
{
    public class AmenityService : IAmenity
    {
        private AsyncInnDbContext _context;

        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenity amenity)
        {
            _context.Amenity.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task GetAmenity(int? id)
        {
            Amenity amenity = _context.
        }

        public async Task UpdateAmenity(Amenity amenity)
        {
            _context.Amenity.Update(amenity);
            await _context.SaveChangesAsync();
        }
    }
}
