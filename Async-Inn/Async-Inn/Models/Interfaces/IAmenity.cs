using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenity
    {
        //Task<Amenity> Create(Amenity amenity);
        Task<AmenityDTO> Create(Amenity amenity);


        Task<List<Amenity>> GetAmenities();
        //Task<List<AmenityDTO>> GetAmenities();


        //Task<Amenity> GetAmenity(int amenityId);
        Task<AmenityDTO> GetAmenity(int amenityId);


        Task<Amenity> UpdateAmenity(int id, Amenity amenity);
        //Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenity);


        Task Delete(int id);
    }
}
