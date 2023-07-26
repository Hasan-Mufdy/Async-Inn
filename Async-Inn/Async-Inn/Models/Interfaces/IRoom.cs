namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room room);
        Task<List<Room>> GetRooms();

        Task<Room> GetRoom(int roomId);

        Task<Room> UpdateRoom(int id, Room room);

        Task Delete(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmenityFromRoom(int roomId, int amenityId);
    }
}
