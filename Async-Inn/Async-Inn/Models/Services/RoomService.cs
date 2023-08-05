using Async_Inn.Data;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace Async_Inn.Models.Services
{
    public class RoomService : IRoom
    {
        private readonly HotelDbContext _context;

        public RoomService(HotelDbContext context)
        {
            _context = context;
        }

        //public IEnumerable<Room> GetRooms()
        //{
        //    return _context.Rooms.Include(r => r.RoomAmenities).ToList();
        //}
        public async Task<RoomDTO> Create(Room room)
        {
            //_context.Rooms.Add(room);
            //await _context.SaveChangesAsync();
            //return room;

            var RoomDTO = new RoomDTO()
            {
                ID = room.Id,
                Name = room.Name,
                Layout = room.Layout,
            };
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return RoomDTO;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int roomId)
        {
            Room room = await _context.Rooms.FindAsync(roomId);
            return room;
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            //var rooms = await _context.Rooms.ToListAsync();
            //return rooms;

            var roomsDTO = await _context.Rooms
            .Include(r  => r.Rooms)
            .Select(r =>  new RoomDTO
            {
                Name = r.Name,
                Layout = r.Layout
            }).ToListAsync();

            return roomsDTO;

        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;

        }


        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            var roomAmenity = new RoomAmenity
            {
                RoomId = roomId,
                AmenityId = amenityId
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            
        }
    }
}
