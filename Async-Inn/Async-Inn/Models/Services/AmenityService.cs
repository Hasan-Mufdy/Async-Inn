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

        public async Task<AmenityDTO> Create(Amenity amenity)
        {
            //_context.Amenities.Add(amenity);
            //await _context.SaveChangesAsync();
            //return amenity;
            AmenityDTO amenityDTO = new AmenityDTO()
            {
                ID = amenity.Id,
                Name = amenity.Name
            };
            //_context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //await _context.SaveChangesAsync();

            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
            
            return amenityDTO;
        }

        public async Task Delete(int id)
        {
            AmenityDTO amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var amenities = await _context.Amenities.Select(a => new AmenityDTO
            {
                ID = a.Id,
                Name = a.Name,
            }).ToListAsync();
            return amenities;
        }

        public async Task<AmenityDTO> GetAmenity(int amenityId)
        {
            //Amenity amenities = await _context.Amenities.FindAsync(amenityId);
            //return amenities;

            var newAmenity = await _context.Amenities.Select(a => new AmenityDTO
            {
                ID = a.Id,
                Name = a.Name,
            }).Where(a => a.ID == amenityId).FirstOrDefaultAsync();

            return newAmenity;
        }

        public async Task<AmenityDTO> UpdateAmenity(int id, Amenity updatedamenity)
        {
            //_context.Entry(amenity).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return amenity;

            var amenity = await GetAmenity(id);
            Amenity amenities = await _context.Amenities.Where(a => a.Id == id).FirstOrDefaultAsync();
            amenity.Name = updatedamenity.Name;
            amenity.ID = id;
            _context.Entry(amenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    } 
}
