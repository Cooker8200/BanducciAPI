﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BanducciAPI.Data;
using BanducciAPI.Models;

namespace BanducciAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanducciHepAsController : ControllerBase
    {
        private readonly BanducciDataContext _context;

        public BanducciHepAsController(BanducciDataContext context)
        {
            _context = context;
        }

        // GET: api/BanducciHepAs
        [HttpGet]
        public IEnumerable<BanducciHepA> GetBanducciHepA()
        {
            return _context.BanducciHepA;
        }

        // GET: api/BanducciHepAs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanducciHepA([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banducciHepA = await _context.BanducciHepA.FindAsync(id);

            if (banducciHepA == null)
            {
                return NotFound();
            }

            return Ok(banducciHepA);
        }

        // PUT: api/BanducciHepAs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanducciHepA([FromRoute] int id, [FromBody] BanducciHepA banducciHepA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != banducciHepA.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(banducciHepA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanducciHepAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BanducciHepAs
        [HttpPost]
        public async Task<IActionResult> PostBanducciHepA([FromBody] BanducciHepA banducciHepA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BanducciHepA.Add(banducciHepA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanducciHepA", new { id = banducciHepA.EmployeeId }, banducciHepA);
        }

        // DELETE: api/BanducciHepAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanducciHepA([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banducciHepA = await _context.BanducciHepA.FindAsync(id);
            if (banducciHepA == null)
            {
                return NotFound();
            }

            _context.BanducciHepA.Remove(banducciHepA);
            await _context.SaveChangesAsync();

            return Ok(banducciHepA);
        }

        private bool BanducciHepAExists(int id)
        {
            return _context.BanducciHepA.Any(e => e.EmployeeId == id);
        }
    }
}