using dotnet_crup_api_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_crup_api_demo.Services.CustomerService
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<bool> AddCustomer(Customer newCustomer);

        Task<Customer> UpdateCustomer(int id, Customer customer);
        Task<bool> DeleteCustomer(int id);

    }
}
