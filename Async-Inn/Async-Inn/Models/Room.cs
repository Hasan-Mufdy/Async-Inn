 namespace Async_Inn.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }

        //
        // nav props:
        public List<RoomAmenity> RoomAmenities { get; set; }
        public IList<HotelRoom> Rooms { get; set; }
        //public Amenity amenity { get; set; }
        //public Room room { get; set; }

    }
}
