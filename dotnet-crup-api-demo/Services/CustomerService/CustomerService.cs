using AutoMapper;
using dotnet_crup_api_demo.Dtos.CustomerDto;
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
        private readonly IMapper _mapper;

        public CustomerService(ApiDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public List<GetCustomerDto> GetAllCustomers()
        {
            List<GetCustomerDto> customers = _mapper.Map<List<GetCustomerDto>>(_context.Customers.ToList());
            return customers;
        }

        public async Task<GetCustomerDto> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

        
            if(customer is not null)
            {
                GetCustomerDto customerDto = _mapper.Map<GetCustomerDto>(customer);
                return customerDto;
            }
               

            throw new Exception("Customer not found.");
        }

        public async Task<GetCustomerDto> UpdateCustomer(int id, Customer customer)
        {
            customer.ID = id;
            _context.Customers.Update(customer);

            try
            {
                await _context.SaveChangesAsync();
                GetCustomerDto customerDto = _mapper.Map<GetCustomerDto>(customer);
                return customerDto;
            }
            catch
            {
                if (_context.Customers.Find(id) == null)
                {
                    throw new Exception("Customer not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);           

            try
            {
                if (customer == null)
                {
                    throw new Exception("customer not found");
                }

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }                      

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
