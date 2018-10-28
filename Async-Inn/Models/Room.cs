using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        // Model properties
        public int ID { get; set; }
        [Required(ErrorMessage = "Please, provide a name for this room. Make it fun!")]
        [Display(Name = "Room Name")]
        public string Name { get; set; }
        // There is no way for the user to select blank. Is it possible to have a blank with an enum?
        [Required(ErrorMessage = "Please, select the layout of this room.")]
        [EnumDataType(typeof(Layout))]
        public int Layout { get; set; }

        // Navigation properties
        public ICollection<HotelRooms> HotelRooms { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        [Display(Name = "Studio")]
        Studio,
        [Display(Name = "One Bedroom")]
        OneBedroom,
        [Display(Name = "Two Bedroom")]
        TwoBedroom,
        [Display(Name = "Penthouse Suite")]
        Penthouse
    }
}
