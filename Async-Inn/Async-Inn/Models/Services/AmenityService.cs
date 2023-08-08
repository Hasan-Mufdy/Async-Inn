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

        /// <summary>
        /// Creates a new Amenity.
        /// </summary>
        /// <param name="amenity">The Amenity object to create.</param>
        /// <returns>The created Amenity.</returns>
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

        /// <summary>
        /// Deletes an Amenity by ID.
        /// </summary>
        /// <param name="id">The ID of the Amenity to delete.</param>
        public async Task Delete(int id)
        {
            AmenityDTO amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a list of all Amenities.
        /// </summary>
        /// <returns>A list of AmenityDTO objects.</returns>
        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var amenities = await _context.Amenities.Select(a => new AmenityDTO
            {
                ID = a.Id,
                Name = a.Name,
            }).ToListAsync();
            return amenities;
        }

        /// <summary>
        /// Retrieves an Amenity by ID.
        /// </summary>
        /// <param name="amenityId">The ID of the Amenity to retrieve.</param>
        /// <returns>The retrieved AmenityDTO.</returns>
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

        /// <summary>
        /// Updates an existing Amenity.
        /// </summary>
        /// <param name="id">The ID of the Amenity to update.</param>
        /// <param name="updatedamenity">The updated Amenity object.</param>
        /// <returns>The updated AmenityDTO.</returns>
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
