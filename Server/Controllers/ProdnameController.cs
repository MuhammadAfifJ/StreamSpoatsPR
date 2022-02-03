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
    public class ProdnameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdnameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Prodname
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prodname>>> GetProdname()
        {
            return await _context.Prodname.ToListAsync();
        }

        // GET: api/Prodname/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prodname>> GetProdname(int id)
        {
            var prodname = await _context.Prodname.FindAsync(id);

            if (prodname == null)
            {
                return NotFound();
            }

            return prodname;
        }

        // PUT: api/Prodname/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdname(int id, Prodname prodname)
        {
            if (id != prodname.ID)
            {
                return BadRequest();
            }

            _context.Entry(prodname).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdnameExists(id))
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
        public async Task<ActionResult<Prodname>> PostProdname(Prodname prodname)
        {
            _context.Prodname.Add(prodname);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdname", new { id = prodname.ID }, prodname);
        }

        // DELETE: api/Prodname/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdname(int id)
        {
            var prodname = await _context.Prodname.FindAsync(id);
            if (prodname == null)
            {
                return NotFound();
            }

            _context.Prodname.Remove(prodname);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdnameExists(int id)
        {
            return _context.Prodname.Any(e => e.ID == id);
        }
    }
}