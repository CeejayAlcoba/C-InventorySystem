using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductHistory
    {
        [Key]
        public int ProductHistoryId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        [ForeignKey("PurchaseOrder")]
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey("SalesOrder")]
        public int? SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        public string Transac { get; set; }
    }
}
