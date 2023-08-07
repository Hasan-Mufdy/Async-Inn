using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        //Task<Room> Create(Room room);
        Task<RoomDTO> Create(Room room);


        //Task<List<Room>> GetRooms();
        Task<List<RoomDTO>> GetRooms();


        //Task<Room> GetRoom(int roomId);
        Task<RoomDTO> GetRoom(int roomId);


        //Task<Room> UpdateRoom(int id, Room room);
        Task<RoomDTO> UpdateRoom(int id, Room room);


        Task<RoomDTO> Delete(int id);

        Task<RoomAmenity> AddAmenityToRoom(int roomId, int amenityId);
        Task<RoomAmenity> RemoveAmenityFromRoom(int roomId, int amenityId);
    }
}
