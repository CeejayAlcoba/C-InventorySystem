﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Uom
    {
        [Key]
        public int UomId { get; set; }
        public string Name { get; set; }
        public double MinimumStockAlert { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
    }
}
