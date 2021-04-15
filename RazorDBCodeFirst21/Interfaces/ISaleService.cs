using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorDBCodeFirst21.Models;

namespace RazorDBCodeFirst21.Interfaces
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetSalesAsync(int maxAmount);
        Task<IEnumerable<Sale>> GetSalesAsync();
        Task AddSaleAsync(Sale sale);
        Task DeleteSaleAsync(Sale sale);
        Task<Sale> GetSaleByIdAsync(int id);
        Task<Customer> GetSalesByCustomerIdAsync(int CustomerId);
    }
}
