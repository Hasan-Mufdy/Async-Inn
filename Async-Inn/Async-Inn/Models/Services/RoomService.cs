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
                Amenities = _context.RoomAmenities
                .Where(r => r.RoomId == room.Id)
                .Select(r => new AmenityDTO
                {
                    ID = r.amenity.Id,
                    Name = r.amenity.Name,

                }).ToList()
            };
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return RoomDTO;
        }

        public async Task<RoomDTO> Delete(int id)
        {
            //Room room = await GetRoom(id);
            //_context.Entry(room).State = EntityState.Deleted;
            //await _context.SaveChangesAsync();

            RoomDTO roomDTO = await GetRoom(id);
            Room room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return roomDTO;

        }

        public async Task<RoomDTO> GetRoom(int roomId)
        {
            //Room room = await _context.Rooms.FindAsync(roomId);
            //return room;

            var room = await _context.Rooms.FindAsync(roomId);

            var roomDto = new RoomDTO
            {
                ID = room.Id,
                Name = room.Name,
                Layout = room.Layout,
                Amenities = _context.RoomAmenities
                    .Where(ra => ra.RoomId == room.Id)
                    .Select(ra => new AmenityDTO
                    {
                        ID = ra.amenity.Id,
                        Name = ra.amenity.Name,
                    }).ToList()
            };

            return roomDto;

        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            //var rooms = await _context.Rooms.ToListAsync();
            //return rooms;

            //var roomsDTO = await _context.Rooms
            //.Include(r  => r.Rooms)
            //.Select(r =>  new RoomDTO
            //{
            //    Name = r.Name,
            //    Layout = r.Layout
            //}).ToListAsync();

            //return roomsDTO;

            return await _context.Rooms
            .Include(r => r.RoomAmenities)
            .ThenInclude(ra => ra.amenity)
            .Select(x => new RoomDTO
            {
                ID = x.Id,
                Name = x.Name,
                Layout = x.Layout,
                Amenities = x.RoomAmenities
                    .Select(ra => new AmenityDTO
                    {
                        ID = ra.amenity.Id,
                        Name = ra.amenity.Name,
                    }).ToList()
            }).ToListAsync();
        }

        public async Task<RoomDTO> UpdateRoom(int id, Room room)
        {
            //_context.Entry(room).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return room;

            RoomDTO roomDTO = await GetRoom(id);

            Room temproom = await _context.Rooms.FindAsync(id);
            temproom.Layout = room.Layout;
            temproom.Name = room.Name;

            _context.Entry(temproom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return roomDTO;

        }

        public async Task<RoomAmenity> AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity
            {
                RoomId = roomId,
                AmenityId = amenityId
            };
            _context.RoomAmenities.Add(roomAmenity);
            await _context.SaveChangesAsync();

            return roomAmenity;
            //_context.Entry(roomAmenity).State = EntityState.Added;
            //await _context.SaveChangesAsync();
        }

        public async Task<RoomAmenity> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(roomId, amenityId);

            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();

            return roomAmenities;
        }
    }
}