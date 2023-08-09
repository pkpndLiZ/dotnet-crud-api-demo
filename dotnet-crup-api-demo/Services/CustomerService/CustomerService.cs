using dotnet_crup_api_demo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace dotnet_crup_api_demo.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ApiDbContext _context;

        public CustomerService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCustomer(Customer newCustomer)
        {
            try
            {
                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
                       
        }       

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

        
            if(customer is not null)          
                return customer;

            throw new Exception("Customer not found.");
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            customer.ID = id;
            _context.Customers.Update(customer);

            try
            {
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (_context.Customers.Find(id) == null)
                {
                    throw new Exception("Customer not found.");
                }
                else
                {
                    throw e;
                }
            }
        }

        public Task<bool> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        /* public async Task<List<Customer>> AddCustomer(Customer newCustomer)
         {
             var customer = _context.Customers.Add(newCustomer);
             _context.SaveChangesAsync();

             return Ok(customer);
         }

         public List<Customer> GetAllCustomers()
         {
             return _context.Customers.ToList();
         }

         public Customer GetCustomerById(int id)
         {
             var customer = _context.Customers.FindAsync(id);

             if (customer == null)
             {
                 return NotFound();
             }
             return customer;
         }

         Customer ICustomerService.AddCustomer(Customer newCustomer)
         {
             throw new NotImplementedException();
         }

         Task<List<Customer>> ICustomerService.GetAllCustomers()
         {
             throw new NotImplementedException();
         }*/
    }
}
