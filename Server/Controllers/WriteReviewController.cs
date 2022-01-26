using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class WriteReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WriteReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(ReviewWriteViewModel review)
        {
           // _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.ReviewId }, review);
        }
    }
}
