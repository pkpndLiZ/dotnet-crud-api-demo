using dotnet_crup_api_demo.Dtos.CustomerDto;
using dotnet_crup_api_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_crup_api_demo.Services.CustomerService
{
    public interface ICustomerService
    {
        List<GetCustomerDto> GetAllCustomers();
        Task<GetCustomerDto> GetCustomerById(int id);
        Task<bool> AddCustomer(Customer newCustomer);

        Task<GetCustomerDto> UpdateCustomer(int id, Customer customer);
        Task<bool> DeleteCustomer(int id);

    }
}
