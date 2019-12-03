using System;
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
    public class BanducciRepairsController : ControllerBase
    {
        private readonly BanducciDataContext _context;

        public BanducciRepairsController(BanducciDataContext context)
        {
            _context = context;
        }

        // GET: api/BanducciRepairs
        [HttpGet]
        public IEnumerable<BanducciRepair> GetBanducciRepair()
        {
            var a = _context;
            return _context.BanducciRepair;
        }

        // GET: api/BanducciRepairs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanducciRepair([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banducciRepair = await _context.BanducciRepair.FindAsync(id);

            if (banducciRepair == null)
            {
                return NotFound();
            }

            return Ok(banducciRepair);
        }

        // PUT: api/BanducciRepairs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanducciRepair([FromRoute] int id, [FromBody] BanducciRepair banducciRepair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != banducciRepair.Id)
            {
                return BadRequest();
            }

            _context.Entry(banducciRepair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanducciRepairExists(id))
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

        // POST: api/BanducciRepairs
        [HttpPost]
        public async Task<IActionResult> PostBanducciRepair([FromBody] BanducciRepair banducciRepair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BanducciRepair.Add(banducciRepair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanducciRepair", new { id = banducciRepair.Id }, banducciRepair);
        }

        // DELETE: api/BanducciRepairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanducciRepair([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banducciRepair = await _context.BanducciRepair.FindAsync(id);
            if (banducciRepair == null)
            {
                return NotFound();
            }

            _context.BanducciRepair.Remove(banducciRepair);
            await _context.SaveChangesAsync();

            return Ok(banducciRepair);
        }

        private bool BanducciRepairExists(int id)
        {
            return _context.BanducciRepair.Any(e => e.Id == id);
        }
    }
}