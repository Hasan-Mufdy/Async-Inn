﻿using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.DTO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Inn_Test
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;

        protected readonly HotelDbContext _db;


        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new HotelDbContext(

                new DbContextOptionsBuilder<HotelDbContext>()
                .UseSqlite(_connection).Options);

            _db.Database.EnsureCreated();
        }


        protected async Task<Hotel> CreateHotel(Hotel hotel)
        {
            hotel = new Hotel()
            {
                Name = "Hotel1",
                StreetAddress = "st",
                City = "Amman",
                Phone = "5465465",
                State = "1"
            };
            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();

            var hotelDTO = new HotelDTO()
            {
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                Phone = hotel.Phone,
                State = hotel.State
            };
            return hotel;
        }

        protected async Task<Room> CreateAndSaveRoom(Room room)
        {

            room = new Room()
            {
                Name = "room",
                Layout = 2
            };
            
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();

            Assert.NotEqual(0, room.Id);

            return room;
        }





        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}
