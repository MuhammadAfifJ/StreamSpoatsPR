using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamSpoatsPR.Server.Data;
using StreamSpoatsPR.Shared;

namespace StreamSpoatsPR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSport()
        {
            return await _context.Sport.ToListAsync();
        }

        // GET: api/Sport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            var sport = await _context.Sport.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }

        // PUT: api/Sport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSport(int id, Sport sport)
        {
            if (id != sport.ID)
            {
                return BadRequest();
            }

            _context.Entry(sport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
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

        // POST: api/Sport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sport>> PostSport(Sport sport)
        {
            _context.Sport.Add(sport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSport", new { id = sport.ID }, sport);
        }

        // DELETE: api/Sport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSport(int id)
        {
            var sport = await _context.Sport.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }

            _context.Sport.Remove(sport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportExists(int id)
        {
            return _context.Sport.Any(e => e.ID == id);
        }
    }
}
