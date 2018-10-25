using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
