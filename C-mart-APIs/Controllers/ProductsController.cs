using C_mart_APIs.Data;
using C_mart_APIs.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_mart_APIs.Controllers
{
    [ApiController]
    [Route("controller")]

    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Route("api/products/{category}")]
        public List<Product> GetProductsByCategory(string category)
        {
            List<Product> products = new List<Product>();
            foreach (var product in _context.Products)
            {
                //var product = _context.Products
                //    .Where(p => p.Name == category)
                //    .FirstOrDefault();
                if (product.Category == category) { products.Add(product); }
            }
            //if (_context.Products == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Products.ToListAsync();
            return products;
        }

        // GET: api/Products
        
        [HttpGet]
        [Route("api/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Products.ToListAsync();
        }



        // GET: api/Products/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //  if (_context.Products == null)
        //  {
        //      return NotFound();
        //  }
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}



        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPut]
        [Route("api/products/{id}")]
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        [HttpPost]
        [Route("api/products")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'CMartAPIDbContext.Products'  is null.");
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        
        [HttpDelete]
        [Route("api/products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
