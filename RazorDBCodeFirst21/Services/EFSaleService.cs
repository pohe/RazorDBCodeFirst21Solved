using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorDBCodeFirst21.Interfaces;
using RazorDBCodeFirst21.Models;

namespace RazorDBCodeFirst21.Services
{
    public class EFSaleService : ISaleService
    {
        private List<Sale> sales;
        private SaleDbContext context;
        public EFSaleService(SaleDbContext service)
        {
            context = service;
        }
        public async Task AddSaleAsync(Sale sale)
        {
            sale.SalesDate = DateTime.Now;
            context.Sales.Add(sale);
            await context.SaveChangesAsync();
        }
        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await context.Sales.FindAsync(id);
        }
        public async Task DeleteSaleAsync(Sale sale)
        {
            if (sale != null)
            {
                context.Sales.Remove(sale);
                await context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Sale>> GetSalesAsync(int maxAmount)
        {
            return await this.context.Set<Sale>().Where(s => s.Amount < maxAmount).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Sale>> GetSalesAsync()
        {
            return await this.context.Set<Sale>().AsNoTracking().ToListAsync();
        }
        public async Task<Customer> GetSalesByCustomerIdAsync(int id)
        {
            Customer Customer = await context.Customers
                .Include(s => s.Sales)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            return Customer;
        }
    }
}
