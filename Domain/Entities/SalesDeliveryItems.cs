using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesDeliveryItems
    {
        [Key]
        public int SalesDeliveryId { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
    }
}
