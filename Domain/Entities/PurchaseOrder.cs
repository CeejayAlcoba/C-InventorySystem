using System;
using System.Collections.Generic;
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
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double BeforeTax { get; set; }
        public double TaxAmount { get; set; }
        public double OtherCharge { get; set; }
        public double Total { get; set; }
    }
}
