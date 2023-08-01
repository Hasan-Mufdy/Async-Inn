using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room room);
        //Task<RoomDTO> Create(RoomDTO room);


        Task<List<Room>> GetRooms();
        //Task<List<RoomDTO>> GetRooms();


        Task<Room> GetRoom(int roomId);
        //Task<RoomDTO> GetRoom(int roomId);


        Task<Room> UpdateRoom(int id, Room room);
        //Task<RoomDTO> UpdateRoom(int id, RoomDTO room);


        Task Delete(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmenityFromRoom(int roomId, int amenityId);
    }
}
