using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRooms
    {
        // Model props
        [Required(ErrorMessage = "There needs to be a Hotel association.")]
        [Display(Name = "Hotel")]
        public int HotelID { get; set; }
        [Required(ErrorMessage = "There needs to be a Room association.")]
        [Display(Name = "Room")]
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Please, enter the Room number.")]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Customers need to know how much the nightly rate for this room is.")]
        public decimal Rate { get; set; }
        [Required(ErrorMessage = "Can customers bring their pets?")]
        public bool PetFriendly { get; set; }

        // Navigation properties
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
