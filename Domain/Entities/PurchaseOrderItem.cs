using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchaseOrderItem
    {
        [Key]
        public int ItemId { get; set; }

        //Many
        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }

        [JsonIgnore]
        public PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public double DiscountAmount { get; set; }
        public double Quantity { get; set; }
        public double TaxPercentage { get; set; }
        public double SubTotal { get; set; }
        public double BeforeTax { get; set; }
        public double TaxAmount { get; set; }
        public double Total { get; set; }
        public bool IsDelete { get; set; }
    }
}
