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
    public class BanducciLocationsController : ControllerBase
    {
        private readonly BanducciDataContext _context;

        public BanducciLocationsController(BanducciDataContext context)
        {
            _context = context;
        }

        // GET: api/BanducciLocations
        [HttpGet]
        public IEnumerable<BanducciLocation> GetBanducciLocation()
        {
            return _context.BanducciLocation;
        }

        // GET: api/BanducciLocations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanducciLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banducciLocation = await _context.BanducciLocation.FindAsync(id);

            if (banducciLocation == null)
            {
                return NotFound();
            }

            return Ok(banducciLocation);
        }

        // PUT: api/BanducciLocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanducciLocation([FromRoute] int id, [FromBody] BanducciLocation banducciLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != banducciLocation.StoreNumber)
            {
                return BadRequest();
            }

            _context.Entry(banducciLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanducciLocationExists(id))
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

        // POST: api/BanducciLocations
        [HttpPost]
        public async Task<IActionResult> PostBanducciLocation([FromBody] BanducciLocation banducciLocation)
        {
            //TODO: investigate address verification through usps api
            if (String.IsNullOrEmpty(banducciLocation.StoreNumber.ToString()) ||
                String.IsNullOrEmpty(banducciLocation.Name) ||
                String.IsNullOrEmpty(banducciLocation.Address) ||
                String.IsNullOrEmpty(banducciLocation.City) ||
                String.IsNullOrEmpty(banducciLocation.State) ||
                String.IsNullOrEmpty(banducciLocation.ZipCode.ToString()))
            {
                return BadRequest("Missing Location Data.  Verify information.");
            }

            _context.BanducciLocation.Add(banducciLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanducciLocation", new { id = banducciLocation.StoreNumber }, banducciLocation);
        }

        private bool BanducciLocationExists(int id)
        {
            return _context.BanducciLocation.Any(e => e.StoreNumber == id);
        }
    }
}