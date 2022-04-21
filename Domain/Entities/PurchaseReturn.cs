using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchaseReturn
    {

        [Key]
        public int PurchaseReturnId { get; set; }
        public string Description { get; set; }
        public DateTime ReturnDate { get; set; }
        [ForeignKey("PurchaseReceipt")]
        public int PurchaseReceiptId { get; set; }
        public PurchaseReceipt PurchaseReceipt { get; set; }
        [ForeignKey("PurchaseOrderItem")]
        public int PurchaseOrderItemId { get; set; }
        public PurchaseOrderItem PurchaseOrderItem { get; set; }
        public double Total { get; set; }

    }
}
