using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDBCodeFirst21.Interfaces;
using RazorDBCodeFirst21.Models;

namespace RazorDBCodeFirst21.Pages.Customers
{
    public class GetAllCustomersModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public string CookieValue { get; set; }
        public IEnumerable<Customer> Customers { get; private set; }

        ICustomerService customerService;
        public GetAllCustomersModel(ICustomerService cService)
        {
            this.customerService = cService;
            Customers = new List<Customer>();
        }
        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(FilterCriteria))
            {
                Customers = await customerService.GetCustomersAsync();
            }
            else
                Customers = await customerService.GetCustomersAsync(FilterCriteria);
        }
    }
}
