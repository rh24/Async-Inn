using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        // Model properties
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        // Navigation properties
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
