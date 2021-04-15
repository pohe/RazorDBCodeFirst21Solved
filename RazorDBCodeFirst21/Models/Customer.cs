using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorDBCodeFirst21.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        public int? Age { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
