using System.Collections.Generic;
using System.Threading.Tasks;
using Async_Inn.Models;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoom
    {
        //Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        //Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        //Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        //Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom);
        //Task DeleteHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        Task<List<HotelRoom>> GetHotelRooms(int hotelID);

        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);

        Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom hotelRoom);

        Task Delete(int id, int roomNumber);
    }
}
