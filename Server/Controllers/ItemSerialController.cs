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
    public class ItemSerialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItemSerialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Serial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Serial>>> GetSerial()
        {
            return await _context.Serial.ToListAsync();
        }

        // GET: api/Serial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Serial>> GetSerial(int id)
        {
            var serial = await _context.Serial.FindAsync(id);

            if (serial == null)
            {
                return NotFound();
            }

            return serial;
        }

        // PUT: api/Sport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerial(int id, Serial serial)
        {
            if (id != serial.ID)
            {
                return BadRequest();
            }

            _context.Entry(serial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerialExists(id))
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
        public async Task<ActionResult<Serial>> PostSerial(Serial serial)
        {
            _context.Serial.Add(serial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerial", new { id = serial.ID }, serial);
        }

        // DELETE: api/ItemSerial/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerial(int id)
        {
            var serial = await _context.Serial.FindAsync(id);
            if (serial == null)
            {
                return NotFound();
            }

            _context.Serial.Remove(serial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerialExists(int id)
        {
            return _context.Serial.Any(e => e.ID == id);
        }
    }
}
