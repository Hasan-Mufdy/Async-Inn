using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);
        //Task<HotelDTO> Create(HotelDTO hotel);

        Task<List<Hotel>> GetHotels();
        //Task<List<HotelDTO>> GetHotels();


        Task<Hotel> GetHotel(int hotelId );
        //Task<HotelDTO> GetHotel(int hotelId);


        Task<Hotel> UpdateHotel(int id, Hotel hotel);
        //Task<HotelDTO> UpdateHotel(int id, HotelDTO hotel);


        Task Delete(int id);
    }
}
