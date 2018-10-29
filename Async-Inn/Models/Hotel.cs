using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Hotel
    {
        // Model props
        public int ID { get; set; }
        [Required(ErrorMessage = "Please, enter a name for the hotel.")]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, enter an address for the hotel.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please, enter the contact information.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        // Navigation properties
        public ICollection<HotelRooms> HotelRooms { get; set; }
    }
}
