//using Async_Inn.Data;
//using Async_Inn.Models.Interfaces;
//using Async_Inn.Models;
//using Microsoft.EntityFrameworkCore;


//namespace Async_Inn.Services
//{
//    public class RoomAmenityRepository : IRoomAmenity
//    {
//        private readonly HotelDbContext _context;

//        public RoomAmenityRepository(HotelDbContext context)
//        {
//            _context = context;
//        }

//        public async Task AddAmenityToRoom(int roomId, int amenityId)
//        {
//            // Check if both Room and Amenity exist
//            var room = await _context.Rooms.FindAsync(roomId);
//            var amenity = await _context.Amenities.FindAsync(amenityId);

//            if (room == null || amenity == null)
//            {
//                // Handle error - room or amenity not found
//                return;
//            }

//            // Add the RoomAmenity relationship
//            var roomAmenity = new RoomAmenity { RoomId = roomId, AmenityId = amenityId };
//            _context.RoomAmenities.Add(roomAmenity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
//        {
//            // Find the RoomAmenity relationship
//            var roomAmenity = await _context.RoomAmenities
//                .FirstOrDefaultAsync(ra => ra.RoomId == roomId && ra.AmenityId == amenityId);

//            if (roomAmenity != null)
//            {
//                // Remove the RoomAmenity relationship
//                _context.RoomAmenities.Remove(roomAmenity);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
