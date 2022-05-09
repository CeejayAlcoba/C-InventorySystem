﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesDeliveryItem
    {
        [Key]
        public int SalesDeliveryItemId { get; set; }
        [ForeignKey("SalesDelivery")]
        public int SalesDeliveryId { get; set; }

        [JsonIgnore]
        public SalesDelivery SalesDelivery { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public bool IsDelete { get; set; }
    }
}
