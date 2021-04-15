using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorDBCodeFirst21.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        [Required]
        [StringLength(20)]
        public string ProductName { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required] 
        public DateTime SalesDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
