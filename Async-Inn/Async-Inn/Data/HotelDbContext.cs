using Async_Inn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Async_Inn.Data
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            ///

            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 1, Name = "hotel 1", City = "Amman", Phone="075354135", State= "Amman", StreetAddress= "Amman street" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 2, Name = "hotel 2", City = "Amman", Phone = "075354135", State = "Amman", StreetAddress = "Amman street" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 3, Name = "hotel 3", City = "Amman", Phone = "075354135", State = "Amman", StreetAddress = "Amman street" });

            ////////////////

            modelBuilder.Entity<Room>().HasData(new Room { Id = 1, Name = "Room 1", Layout = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 2, Name = "Room 2", Layout = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 3, Name = "Room 3", Layout = 1 });

            ////////////////

            modelBuilder.Entity<Amenity>().HasData(new Amenity { Id = 1, Name = "AMN_1" });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { Id = 2, Name = "AMN_2" });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { Id = 3, Name = "AMN_3" });

            modelBuilder.Entity<RoomAmenity>().HasKey(i => new { i.RoomId, i.AmenityId });

            ///////////////

            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { HotelID = 1, RoomNumber = 101, RoomID = 1 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { HotelID = 1, RoomNumber = 102, RoomID = 2 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { HotelID = 2, RoomNumber = 201, RoomID = 2 });

            // many to many
            modelBuilder.Entity<RoomAmenity>().HasKey(ra => new { ra.RoomId, ra.AmenityId });

            ///////////////

            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity { RoomId = 1, AmenityId = 1 });
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity { RoomId = 2, AmenityId = 2 });
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity { RoomId = 3, AmenityId = 3 });

            modelBuilder.Entity<HotelRoom>().HasKey(i => new { i.RoomNumber, i.HotelID });
        }
    }
}
