﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesDelivery
    {
        [Key]
        public int SalesDeliveryId { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        [ForeignKey("SalesOrder")]
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        [ForeignKey("Shipper")]
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }
        public bool IsDelete { get; set; }
    }
}
