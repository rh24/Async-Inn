using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Amenity
    {
        // Model props
        public int ID { get; set; }
        [Required(ErrorMessage = "What's this amenity called?")]
        [Display(Name = "Type of service")]
        public string Name { get; set; }

        // Navigation properties
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
