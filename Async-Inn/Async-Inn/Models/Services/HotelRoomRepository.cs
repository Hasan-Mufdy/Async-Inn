using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private readonly HotelDbContext _context;

        public HotelRoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            var HotelRoom = await _context.HotelRooms.Where(x => x.HotelId == hotelId && x.RoomNumber == roomNumber).FirstOrDefaultAsync();
            return HotelRoom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelID)
        {
            var hotelRoom = await _context.HotelRooms.Where(x=>x.HotelId == hotelID).Include(x => x.rooms).ThenInclude(x => x.Rooms).ToListAsync();
            List<HotelRoom> l = new List<HotelRoom>();
            foreach(var HotelRoom in hotelRoom)
            {
                l.Add(await GetHotelRoom(HotelRoom.HotelId, HotelRoom.RoomNumber));
            }
            return l;
        }

        public async Task<HotelRoom> UpdateHotelRoom(int hotelId,  HotelRoom hotelRoom)
        {
            //if (hotelId != hotelRoom.HotelId || roomNumber != hotelRoom.RoomNumber)
            //{
            //    throw new ArgumentException("HotelId or RoomNumber mismatch.");
            //}

            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            var hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            if (hotelRoom != null)
            {
                _context.HotelRooms.Remove(hotelRoom);
                await _context.SaveChangesAsync();
            }
        }
    }
}