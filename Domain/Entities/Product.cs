using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int Code { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; } 
        public int TotalPrice { get; set; }
    }
}
