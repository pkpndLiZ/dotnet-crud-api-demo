using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_crup_api_demo.Models;
using dotnet_crup_api_demo.Services.CustomerService;
using dotnet_crup_api_demo.Dtos.CustomerDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_crup_api_demo.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
    
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService,IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
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
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] CreateCustomerDto customerDto)
        {
          

            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }

            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);
                await _customerService.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.ID }, customer);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }


            // return Ok("ok");
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDto customerDto)
        {

            // _context.Entry(customer).State = EntityState.Modified;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);
                await _customerService.UpdateCustomer(id, customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Customer not found") 
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
                }
            }
            
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
            }                                    

        }
    }
}

