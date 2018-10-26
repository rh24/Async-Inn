using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenity
    {
        // Model props
        public int ID { get; set; }
        public string String { get; set; }

        // Navigation properties
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
