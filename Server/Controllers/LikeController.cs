using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamSpoatsPR.Server.Data;
using StreamSpoatsPR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LikeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetLikeList")]
        public async Task<ActionResult<List<Like>>> GetLikeList()
        {
            var Like = await _context.Likes.ToListAsync();

            if (Like == null)
            {
                return NotFound();
            }

            return Like;
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Like>> PostLike(Like like)
        {
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLike", new { id = like.LikeId }, like);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Like>> GetLike(int id)
        {
            var like = await _context.Likes.FindAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }

        [HttpGet("{UserId}")]
        [Route("AddLike")]
        public async Task<ActionResult<List<Like>>> AddLike(int ProductId)
        {
            var Like = await _context.Likes.Where(x => x.ProductId == ProductId).ToListAsync();

            if (Like == null)
            {
                return NotFound();
            }

            return Like;
        }

    }
}
