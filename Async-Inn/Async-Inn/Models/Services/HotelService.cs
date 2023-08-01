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

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }
        //public async Task<HotelDTO> Create(HotelDTO newhotel)
        //{
        //    Hotel hotel = new Hotel()
        //    {
        //        Name = newhotel.Name.Split(" ").First()
        //    }
        //    _context.Hotels.Add(hotel);
        //    await _context.SaveChangesAsync();
        //    return hotel;
        //}

        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int hotelId)
        {
            Hotel hotel = await _context.Hotels.FindAsync(hotelId);
            return hotel;
        }
        //public async Task<HotelDTO> GetHotel(int hotelId)
        //{
        //    var hotelDTO = _context.Hotels.Select(s => new HotelDTO
        //    {
        //        Name = s.Name,
        //        StreetAddress = s.StreetAddress,
        //        City = s.City,
        //        State = s.State,
        //        Phone = s.Phone,
        //        Rooms = s.rooms.Select(t => new HotelDTO()
        //        {
        //            Rooms = t.Rooms
        //        })
        //    }).FirstOrDefault(x => x.ID == hotelId);
        //}

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
