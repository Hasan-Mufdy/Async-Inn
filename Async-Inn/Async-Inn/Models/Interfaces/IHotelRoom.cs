using System.Collections.Generic;
using System.Threading.Tasks;
using Async_Inn.Models;
using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoom
    {
        //Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoom hotelRoom);


        //Task<List<HotelRoom>> GetHotelRooms();
        Task<List<HotelRoomDTO>> GetHotelRooms();


        //Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);


        //Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom hotelRoom);
        Task<HotelRoomDTO> UpdateHotelRoom(int id, int roomNumber,HotelRoom hotelRoom);

        Task<HotelRoomDTO> Delete(int id, int roomNumber);
    }
}





//Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
//Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
//Task<List<HotelRoom>> GetHotelRooms(int hotelId);
//Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom);
//Task DeleteHotelRoom(int hotelId, int roomNumber);