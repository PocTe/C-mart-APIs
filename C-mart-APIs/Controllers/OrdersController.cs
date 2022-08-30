using C_mart_APIs.Data;
using C_mart_APIs.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_mart_APIs.Controllers
{
    
    [ApiController]
    [Route("controller")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        
        [HttpGet]
        [Route("api/orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        
        [HttpGet]
        [Route("api/orderbyid/{customerid}")]
        public List<Order> GetOrderById(int customerId)
        {
            //if (_context.Orders == null)
            //{
            //    return NotFound();
            //}
            //  var order = await _context.Orders.FindAsync(id);

            //  if (order == null)
            //  {
            //      return NotFound();
            //  }

            List<Order> orders = new List<Order>();
            foreach (var order in _context.Orders)
            {
                if (order.CustomerId == customerId)
                {
                    orders.Add(order);
                }
            }

            return orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder(int id, Order order)
        //{
        //    if (id != order.OrderId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("api/Orders")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'CMartAPIDbContext.Orders'  is null.");
            }
            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder(int id)
        //{
        //    if (_context.Orders == null)
        //    {
        //        return NotFound();
        //    }
        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
       
        private  bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}

    

