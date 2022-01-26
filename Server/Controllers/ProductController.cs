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
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).
                Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review).ToListAsync();

        }

       

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).
                Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review).Where(x=>x.ProductId==id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            var Purchases = await _context.Purchases.AsNoTracking().Where(x=>x.ItemSerial==product.ItemSerial).FirstOrDefaultAsync();
            if (Purchases == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(Purchases);
            await _context.SaveChangesAsync();

            var Review = await _context.Reviews.AsNoTracking().Where(x => x.ReviewId == Purchases.ReviewId).FirstOrDefaultAsync();
            if (Review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(Review);
            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        [HttpGet]
        [Route("GetProductByUserAsync")]
        public async Task<List<Product>> GetProductByUserAsync(string UserId)
        {

            return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                .Where(x=>x.Purchase.Review.UserId==UserId).ToListAsync();
        }

        [HttpGet]
        [Route("GetProductByConditionAsync")]
        public async Task<List<Product>> GetWhere(int ItemType,  int BrandName, int SportName)
        {
            if (ItemType!=0  && BrandName!=0 && SportName!=0)
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
               .Where(x => x.ItemType == ItemType && x.BrandName == BrandName && x.SportName == SportName).ToListAsync();
            }
            else if (ItemType != 0 &&  BrandName != 0 )
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                               .Where(x => x.ItemType == ItemType  && x.BrandName == BrandName).ToListAsync();

            }
            else if (ItemType != 0  )
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                               .Where(x => x.ItemType == ItemType ).ToListAsync();

            }
            if (ItemType != 0)
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
               .Where(x => x.ItemType == ItemType).ToListAsync();
            }
            else if (BrandName != 0)
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                               .Where(x => x.BrandName == BrandName).ToListAsync();

            }
            else if (ItemType != 0)
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                               .Where(x => x.ItemType == ItemType).ToListAsync();

            }

            else if (ItemType == 0  && BrandName == 0 && SportName == 0)
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
               .ToListAsync();
            }
            else if (ItemType == 0 && BrandName == 0)
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                               .Where(x => x.SportName == SportName).ToListAsync();

            }
            else if (ItemType == 0 )
            {
                return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                               .Where(x =>  x.BrandName == BrandName && x.SportName == SportName).ToListAsync();

            }

            

            return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                .Where(x => x.ItemType == ItemType  &&  x.BrandName == BrandName && x.SportName == SportName).ToListAsync();
            //return await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
            //   .Where(x => x.ItemType == ItemType || x.Type.ItemColor == ItemColor || x.Type.ItemSize == ItemSize || x.BrandName == BrandName || x.SportName == SportName).ToListAsync();
        }

        #region Get top 5 Product 
        [HttpGet]
        [Route("GetTopAsync")]
        public async Task<List<Product>> GetTopAsync()
        {
            List<Product> products = new List<Product>();
            var likelist = await _context.Likes.ToListAsync();
            var Toplike = likelist.GroupBy(x => x.ProductId).Select(grp => new
            {
                likeId = grp.Key,
                likelist=grp.ToList(),
                count = grp.Count()
            });
            var ToplikeOder = Toplike.OrderByDescending(x => x.count);
            foreach(var n in ToplikeOder)
            {
                foreach(var r in n.likelist)
                {
                    var product = await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review)
                                  .Where(x=>x.ProductId==r.ProductId).FirstOrDefaultAsync();
                    products.Add(product);
                }
            }
            if(products.Count!=5)
            {
               var productList= await _context.Products.Include(x => x.Purchase).Include(x => x.Sport).Include(x => x.Type).Include(x => x.Brand).Include(x => x.Purchase.Review).ToListAsync();
               foreach(var n in productList)
                {
                    if(!products.Any(x=>x.ProductId==n.ProductId))
                    {
                        products.Add(n);
                    }
                    if (products.Count == 5)
                    {
                        return products;
                    }
                }
            }
            else
            {
                return products;
            }
            return products;
           
        }
        #endregion

      

    }
}
