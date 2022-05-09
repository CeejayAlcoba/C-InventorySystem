using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesOrder
    {
        [Key]
        public int SalesOrderId { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("SalesChannel")]
        public int SalesChannelId { get; set; }
        public SalesChannel SalesChannel { get; set; }
        [ForeignKey("SalesOrderId")]
        public ICollection<SalesOrderItem> SalesOrderItem { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
