using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;

namespace Async_Inn.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRoom
        [HttpGet]
        //[Route("{hotelID}")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms()
        {
            return await _hotelRoom.GetHotelRooms();
        }

        // GET: api/HotelRoom/5
        [HttpGet]
        [Route("Hotels/{id}/Room/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int id, int roomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(id, roomNumber);
            return hotelRoom;
        }

        // PUT: api/HotelRoom/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelID)
            {
                return BadRequest();
            }

            var updateHotel = await _hotelRoom.UpdateHotelRoom(id, hotelRoom);
            return Ok(updateHotel);
        }

        // POST: api/HotelRoom
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            //return await _hotelRoom.CreateHotelRoom(hotelRoom);
            await _hotelRoom.CreateHotelRoom(hotelRoom);
            return CreatedAtAction("GetHotelRoom", new { HotelID = hotelRoom.HotelID }, hotelRoom);
        }

        // DELETE: api/HotelRoom/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, int roomNumber)
        {
            await _hotelRoom.Delete(id, roomNumber);
            return NoContent();
        }
    }
}
