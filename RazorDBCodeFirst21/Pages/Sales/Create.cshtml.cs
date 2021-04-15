using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDBCodeFirst21.Interfaces;
using RazorDBCodeFirst21.Models;

namespace RazorDBCodeFirst21.Pages.Sales
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Sale Sale { get; set; } = new Sale();

        ISaleService saleService;
        public CreateModel(ISaleService service)
        {
            this.saleService = service;
        }
        public IActionResult OnGet(int id)
        {
            Sale.CustomerId = id;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await saleService.AddSaleAsync(Sale);
            return RedirectToPage("GetAllSales");
        }
    }
}
