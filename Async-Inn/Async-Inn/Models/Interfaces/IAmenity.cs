namespace Async_Inn.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> Create(Amenity amenity);
        Task<List<Amenity>> GetAmenities();

        Task<Amenity> GetAmenity(int amenityId);

        Task<Amenity> UpdateAmenity(int id, Amenity amenity);

        Task Delete(int id);
    }
}
