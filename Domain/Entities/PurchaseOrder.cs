using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        // one
        [ForeignKey("PurchaseOrderId")]
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double BeforeTax { get; set; }
        public double TaxAmount { get; set; }
        public double OtherCharge { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
