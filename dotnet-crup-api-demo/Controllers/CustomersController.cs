using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_crup_api_demo.Models;
using dotnet_crup_api_demo.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_crup_api_demo.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
    
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        //GET api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);
                return Ok(customer);                

            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
        {
            // _context.Customers.Add(customer);
            // await _context.SaveChangesAsync();

            try
            {
                await _customerService.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.ID}, customer);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
         

            // return Ok("ok");
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, [FromBody] Customer customer)
        {

            // _context.Entry(customer).State = EntityState.Modified;

            customer.ID = id;
            _context.Customers.Update(customer);

            try
            {
                await _context.SaveChangesAsync();
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

        // DELETE api/customers/5
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

