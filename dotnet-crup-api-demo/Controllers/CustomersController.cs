using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_crup_api_demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_crup_api_demo.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ApiDbContext _context;

        public CustomersController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(_context.Customers.ToList());
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = _context.Customers.Find(id); 

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCustomer", new { id = customer.ID }, customer);
            return Ok("ok");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, [FromBody]Customer customer)
        {
            
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (_context.Customers.Find(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }

            return NoContent(); //204 No Content
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var student = await _context.Customers.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

