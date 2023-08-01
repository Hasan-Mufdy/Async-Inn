using Async_Inn.Data;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class AmenityService : IAmenity
    {
        private readonly HotelDbContext _context;

        public AmenityService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
            return amenity;
            //AmenityDTO amenityDto = new AmenityDTO()
            //{
            //    ID = Aminity.Id,
            //    Name = Aminity.Name,
            //};
            //_context.Amenities.Add(aminity);
            //await _context.SaveChangesAsync();
            //return amenityDto;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> GetAmenity(int amenityId)
        {
            Amenity amenities = await _context.Amenities.FindAsync(amenityId);
            return amenities;
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;

            //var amenty = await GetAmenitieId(id);
            //Amenities amenity = await _context.Amenities.Where(a => a.Id == id).FirstOrDefaultAsync();
            //amenity.Name = updateAmenites.Name;
            //amenity.Id = id;
            //_context.Entry(amenity).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return amenty;
        }
    } 
}
