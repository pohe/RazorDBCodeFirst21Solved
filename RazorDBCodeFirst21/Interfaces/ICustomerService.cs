using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorDBCodeFirst21.Models;

namespace RazorDBCodeFirst21.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(string filter);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);
    }
}
