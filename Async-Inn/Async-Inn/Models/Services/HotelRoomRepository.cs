using Async_Inn.Data;
using Async_Inn.Models.DTO;
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

        //public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        //{
        //    _context.HotelRooms.Add(hotelRoom);
        //    await _context.SaveChangesAsync();
        //    return hotelRoom;
        //}

        /// <summary>
        /// Creates a new HotelRoom.
        /// </summary>
        /// <param name="hotelRoom">The HotelRoom object to create.</param>
        /// <returns>The created HotelRoomDTO.</returns>
        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoom hotelRoom)
        {
            HotelRoom hotelRoomToCreate = new HotelRoom()
            {
                HotelID = hotelRoom.HotelID,
                Rate = hotelRoom.Rate,
                RoomNumber = hotelRoom.RoomNumber,
                rooms = await _context.Rooms.Where(x => x.Id == hotelRoom.RoomID).FirstOrDefaultAsync(),
                hotels = await _context.Hotels.Where(x => x.ID == hotelRoom.HotelID).FirstOrDefaultAsync()
            };

            var hotelDTO = new HotelRoomDTO()
            {
                HotelID = hotelRoom.HotelID,
                RoomID = hotelRoom.RoomID,
                Rate = hotelRoom.Rate,
                RoomNumber = hotelRoom.RoomNumber,
                PetFriendly = hotelRoom.PetFriendly,
            };

            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelDTO;
        }

        //public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        //{
        //    //var HotelRoom = await _context.HotelRooms.Where(x => x.HotelID == hotelId && x.RoomNumber == roomNumber).FirstOrDefaultAsync();
        //    //return HotelRoom;

        //    HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomNumber);
        //    return hotelRoom;
        //}

        /// <summary>
        /// Retrieves a HotelRoom by hotel ID and room number.
        /// </summary>
        /// <param name="hotelId">The ID of the hotel.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <returns>The retrieved HotelRoomDTO.</returns>
        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
        {
            var HotelRoom = await _context.HotelRooms.Where(x => x.HotelID == hotelId && x.RoomNumber == roomNumber).FirstOrDefaultAsync();
            var HotelRoomDTO = new HotelRoomDTO()
            {
                HotelID = HotelRoom.HotelID,
                RoomNumber = HotelRoom.RoomNumber,
                PetFriendly = HotelRoom.PetFriendly,
                Rate = HotelRoom.Rate,
                RoomID = HotelRoom.RoomID
            };
            return HotelRoomDTO;
        }

        /// <summary>
        /// Retrieves a list of all HotelRooms.
        /// </summary>
        /// <returns>A list of HotelRoomDTO objects.</returns>
        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {

            //var hotelrooms = await _context.HotelRooms.ToListAsync();
            //return hotelrooms;

                 return await _context.HotelRooms
                .Include(hr => hr.hotels)
                .Include(hr => hr.rooms).ThenInclude(r => r.RoomAmenities).ThenInclude(ra => ra.amenity)
                .Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelID,
                    RoomID = x.RoomID,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    Room = new RoomDTO
                    {
                        ID = x.rooms.Id,
                        Name = x.rooms.Name,
                        Amenities = x.rooms.RoomAmenities.Select(ra => new AmenityDTO
                        {
                            ID = ra.amenity.Id,
                            Name = ra.amenity.Name
                        }).ToList()
                    }
                }).ToListAsync();
        }

        /// <summary>
        /// Updates an existing HotelRoom.
        /// </summary>
        /// <param name="hotelId">The ID of the hotel.</param>
        /// <param name="roomId">The ID of the room.</param>
        /// <param name="hotelRoom">The updated HotelRoom object.</param>
        /// <returns>The updated HotelRoomDTO.</returns>
        public async Task<HotelRoomDTO> UpdateHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom)
        {
            var hotels = await _context.HotelRooms.Where(x => x.HotelID == hotelId && x.RoomNumber == roomId).FirstOrDefaultAsync();
            var Temproom = await GetHotelRoom(hotelId, roomId);

            Temproom.RoomNumber = hotelRoom.RoomNumber;
            Temproom.Rate = hotelRoom.Rate;
            Temproom.PetFriendly = hotelRoom.PetFriendly;
            hotels.HotelID = hotelRoom.HotelID;
            hotels.RoomID = hotelRoom.RoomID;
            hotels.RoomNumber = hotelRoom.RoomNumber;
            hotels.Rate = hotelRoom.Rate;
            hotels.PetFriendly = hotelRoom.PetFriendly;


            _context.Entry(hotels).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Temproom;
        }

        /// <summary>
        /// Deletes a HotelRoom by hotel ID and room number.
        /// </summary>
        /// <param name="hotelId">The ID of the hotel.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <returns>The deleted HotelRoomDTO.</returns>
        public async Task<HotelRoomDTO> Delete(int hotelId, int roomNumber)
        {
            var HotelRoomDTO = await GetHotelRoom(hotelId, roomNumber);
            var HotelRoom = await _context.HotelRooms.Where(x => x.HotelID == hotelId && x.RoomNumber == roomNumber).FirstOrDefaultAsync();
            _context.HotelRooms.Remove(HotelRoom);
            await _context.SaveChangesAsync();
            return HotelRoomDTO;
        }
    }
}