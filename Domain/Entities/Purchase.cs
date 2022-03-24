using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public int Total { get; set; }
    }
}
