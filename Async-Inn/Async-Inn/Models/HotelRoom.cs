using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class HotelRoom
    {
        [Key]
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        [Key]
        public int RoomId { get; set; }

        public decimal Rate { get; set; }
        public bool PetFriendly  { get; set; }
        // nav props
        public Hotel? hotels { get; set; }
        public Room? rooms { get; set; }
    }
}
