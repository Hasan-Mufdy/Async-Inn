using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Async_Inn.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<RoomAmenity> RoomAmenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 1, Name = "hotel 1", City = "Amman", Phone="075354135", State= "Amman", StreetAddress= "Amman street" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 2, Name = "hotel 2", City = "Amman", Phone = "075354135", State = "Amman", StreetAddress = "Amman street" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 3, Name = "hotel 3", City = "Amman", Phone = "075354135", State = "Amman", StreetAddress = "Amman street" });

            ////////////////

            modelBuilder.Entity<Room>().HasData(new Room { Id = 1, Name = "Room 1", Amenities = "AM_1", Layout = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 2, Name = "Room 2", Amenities = "AM_2", Layout = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 3, Name = "Room 3", Amenities = "AM_3", Layout = 1 });

            ////////////////

            modelBuilder.Entity<Amenity>().HasData(new Amenity { Id = 1, Name = "AMN_1" });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { Id = 2, Name = "AMN_2" });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { Id = 3, Name = "AMN_3" });

            modelBuilder.Entity<RoomAmenity>().HasKey(i => new { i.RoomId, i.AmenityId });

        }
    }
}
