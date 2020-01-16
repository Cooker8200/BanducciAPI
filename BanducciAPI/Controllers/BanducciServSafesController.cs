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
    public class BanducciServSafesController : ControllerBase
    {
        private readonly BanducciDataContext _context;

        public BanducciServSafesController(BanducciDataContext context)
        {
            _context = context;
        }

        // GET: api/BanducciServSafes
        [HttpGet]
        public IEnumerable<BanducciServSafe> GetBanducciServSafe()
        {
            return _context.BanducciServSafe;
        }

        // GET: api/BanducciServSafes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanducciServSafe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banducciServSafe = await _context.BanducciServSafe.FindAsync(id);

            if (banducciServSafe == null)
            {
                return NotFound();
            }

            return Ok(banducciServSafe);
        }

        // PUT: api/BanducciServSafes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanducciServSafe([FromRoute] int id, [FromBody] BanducciServSafe banducciServSafe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != banducciServSafe.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(banducciServSafe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanducciServSafeExists(id))
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

        // POST: api/BanducciServSafes
        [HttpPost]
        public async Task<IActionResult> PostBanducciServSafe([FromBody] BanducciServSafe banducciServSafe)
        {
            var employeeController = new BanducciEmployeesController(_context);
            var employees = employeeController.GetBanducciEmployee();
            var employeeIds = new List<int>();
            var matchedEmployee = employees.First(x => (x.EmployeeId == banducciServSafe.EmployeeId) || (x.FirstName == banducciServSafe.FirstName && x.LastName == banducciServSafe.LastName));
            foreach (var emp in employees)
            {
                employeeIds.Add(emp.EmployeeId);
            }
            if (!employeeIds.Contains(banducciServSafe.EmployeeId))
            {
                return BadRequest("EmployeeId does not exist in Employee database.");
            }

            banducciServSafe.FirstName = matchedEmployee.FirstName;
            banducciServSafe.LastName = matchedEmployee.LastName;
            banducciServSafe.EmployeeId = matchedEmployee.EmployeeId;

            _context.BanducciServSafe.Add(banducciServSafe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanducciServSafe", new { id = banducciServSafe.EmployeeId }, banducciServSafe);
        }

        // DELETE: api/BanducciServSafes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanducciServSafe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banducciServSafe = await _context.BanducciServSafe.FindAsync(id);
            if (banducciServSafe == null)
            {
                return NotFound();
            }

            _context.BanducciServSafe.Remove(banducciServSafe);
            await _context.SaveChangesAsync();

            return Ok(banducciServSafe);
        }

        private bool BanducciServSafeExists(int id)
        {
            return _context.BanducciServSafe.Any(e => e.EmployeeId == id);
        }
    }
}