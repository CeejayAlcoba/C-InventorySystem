using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchaseReceipt
    {

        [Key]
        public int PurchaseReceiptId { get; set; }
        public string Description { get; set; }
        public DateTime ReceiptDate { get; set; }
        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public string Location { get; set; }
        public double Total { get; set; }
    }
}
