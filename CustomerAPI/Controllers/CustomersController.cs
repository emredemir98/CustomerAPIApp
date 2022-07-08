using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerAPI;
using CustomerAPI.Data;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            if (customer.FirstName == string.Empty || customer.LastName == string.Empty || customer.TcNo == string.Empty
                || customer.Email == string.Empty || customer.Adress == string.Empty || customer.TelNo == string.Empty)
            {

                return Problem("Entity set 'DataContext.Customers'  is empty.");

            }
            customer.Siradisi = CustomerSiradisi(customer.FirstName);
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
               
                 await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'DataContext.Customers'  is null.");
          }
            customer.Siradisi = CustomerSiradisi(customer.FirstName);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool CustomerSiradisi(string name)
        {
            int total = 0;
            // Build a list of vowels up front:      

            total += name.ToLower().Count(v => v == 'a');
            if(total >= 3)
                return true;
            total = 0;
            total += name.ToLower().Count(v => v == 'e');
            if (total >= 3)
                return true;
            total = 0;
            total += name.ToLower().Count(v => v == 'i');
            if (total >= 3)
                return true;
            total = 0;
            total += name.ToLower().Count(v => v == 'o');
            if (total >= 3)
                return true;
            total = 0;
            total += name.ToLower().Count(v => v == 'u');
            if (total >= 3)
                return true;
            total = 0;   
            return false;
        }
    }
}
