using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesReturn
    {
        [Key]
        public int SalesReturnId { get; set; }
        public string Description { get; set; }
        public DateTime ReturnDate { get; set; }
        [ForeignKey("SalesOrder")]
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public string Location { get; set; }
        //[ForeignKey("SalesDeliveryItems")]
        //public int SalesDeliveryItemId { get; set; }
        //public SalesDeliveryItem SalesDeliveryItems { get; set; }
        public double Total { get; set; }
    }
}
