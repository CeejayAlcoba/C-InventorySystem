﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}