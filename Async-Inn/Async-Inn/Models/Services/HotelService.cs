using Async_Inn.Data;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Async_Inn.Models.Services
{
    public class HotelService : IHotel
    {

        private readonly HotelDbContext _context;

        public HotelService(HotelDbContext context)
        {
            _context = context;
        }

        //public async Task<Hotel> Create(Hotel hotel)
        //{
        //    _context.Hotels.Add(hotel);
        //    await _context.SaveChangesAsync();
        //    return hotel;
        //}
        public async Task<HotelDTO> Create(Hotel newhotel)
        {
            HotelDTO hotel = new HotelDTO
            {
                Name = newhotel.Name,
                State = newhotel.State,
                StreetAddress = newhotel.StreetAddress,
                City = newhotel.City,
                Phone = newhotel.Phone,

            };
            _context.Hotels.Add(newhotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            HotelDTO hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        //public async Task<Hotel> GetHotel(int hotelId)
        //{
        //    Hotel hotel = await _context.Hotels.FindAsync(hotelId);
        //    return hotel;
        //}
        public async Task<HotelDTO> GetHotel(int hotelId)
        {
            var hotelDTO = _context.Hotels.Select(s => new HotelDTO
            {
                Name = s.Name,
                StreetAddress = s.StreetAddress,
                City = s.City,
                State = s.State,
                Phone = s.Phone,
                //Rooms = s.rooms.Select(t => new HotelDTO()
                //{
                  //  Rooms = t.Rooms
                //})
            }).FirstOrDefault(x => x.ID == hotelId);
            return hotelDTO;
        }

        /// ///////////////////////////////////////////////////////////////////////////////////////

        //public async Task<List<Hotel>> GetHotels()
        //{
        //    var hotels = await _context.Hotels.ToListAsync();
        //    return hotels;
        //}
        public async Task<List<HotelDTO>> GetHotels()
        {
            var hotelDTOs = await _context.Hotels
        //.Include(h => h.Rooms)
        .Include(h => h.HotelRooms)
        .Include(h => h.Rooms)
        .ThenInclude(r => r.Amenities)
        .Select(s => new HotelDTO
        {
            ID = s.ID,
            Name = s.Name,
            StreetAddress = s.StreetAddress,
            City = s.City,
            State = s.State,
            Phone = s.Phone,
            Rooms = s.Rooms.Select(r => new HotelRoomDTO
            {
                HotelID = r.HotelID,
                RoomNumber = r.RoomNumber,
                Rate = r.Rate,
                PetFriendly = r.PetFriendly,
                RoomID = r.RoomID,
                Room = new RoomDTO
                {
                    ID = r.Room.ID,
                    Name = r.Room.Name,
                    Layout = r.Room.Layout.Name,
                    Amenities = r.Room.Amenities.Select(a => new AmenityDTO
                    {
                        ID = a.Amenity.ID,
                        Name = a.Amenity.Name
                    }).ToList()
                }
            }).ToList()
        })
        .ToListAsync();

            return hotelDTOs;
        }


        public async Task<HotelDTO> UpdateHotel(int id, Hotel hotel)
        {
            //_context.Entry(hotel).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return hotel;
            var hotels = await _context.Hotels.Where(h  => h.ID == id).ToListAsync();
            var updatedHotel = new HotelDTO
            {
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                State = hotel.State,
                City = hotel.City,
                Phone = hotel.Phone,
            };
            updatedHotel.State = hotel.State;
            updatedHotel.StreetAddress = hotel.StreetAddress;
            updatedHotel.State = hotel.State;
            updatedHotel.City = hotel.City;
            updatedHotel.Phone = hotel.Phone;

            _context.Entry(updatedHotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedHotel;

        }
    }
}
