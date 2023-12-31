﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Async_Inn.Controller
{
    [Authorize(Roles = "District Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private readonly IHotel _hotel;
        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        //private readonly HotelDbContext _context;

        //public HotelsController(HotelDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Hotels
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
          //if (_context.Hotels == null)
          //{
          //    return NotFound();
          //}
          //  return await _context.Hotels.ToListAsync();
          var list = await _hotel.GetHotels();
            return Ok(list);
        }

        // GET: api/Hotels/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
          var hotel = await _hotel.GetHotel(id);
          return hotel; // ok(hotel)
            //if (_context.Hotels == null)
          //{
          //    return NotFound();
          //}
          //  var hotel = await _context.Hotels.FindAsync(id);

          //  if (hotel == null)
          //  {
          //      return NotFound();
          //  }

          //  return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }

            var updateHotel = await _hotel.UpdateHotel(id, hotel);
            return Ok(updateHotel);
        }


        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            //if (_context.Hotels == null)
            //{
            //    return Problem("Entity set 'HotelDbContext.Hotels'  is null.");
            //}
            //  _context.Hotels.Add(hotel);
            //  await _context.SaveChangesAsync();

            //await _hotel.Create(hotel);
            //return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);

            HotelDTO newHotel = await _hotel.Create(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);


        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotel.Delete(id);
            return NoContent();
            //if (_context.Hotels == null)
            //{
            //    return NotFound();
            //}
            //var hotel = await _context.Hotels.FindAsync(id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            //_context.Hotels.Remove(hotel);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

        //private bool HotelExists(int id)
        //{
        //    return (_hotel.Hotels?.Any(e => e.ID == id)).GetValueOrDefault();
        //}
    }
}
