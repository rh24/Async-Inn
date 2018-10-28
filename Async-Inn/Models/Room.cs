using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        // Model properties
        public int ID { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }

        // Navigation properties
        public ICollection<HotelRooms> HotelRooms { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
