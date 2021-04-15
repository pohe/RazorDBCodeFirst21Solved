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
    public class DeleteModel : PageModel
    {
        ISaleService saleService;
        public DeleteModel(ISaleService sService)
        {
            this.saleService = sService;
        }
        [BindProperty]
        public Sale Sale { get; set; }
        public async Task OnGetAsync(int id)
        {
            Sale = await saleService.GetSaleByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await saleService.DeleteSaleAsync(Sale);

            return RedirectToPage("GetAllSales");
        }
    }
}
