using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        public double Name { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
    }
}
