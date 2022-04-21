using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Uom")]
        public int UomId { get; set; }
        public Uom Uom { get; set; }
        public double Quantity { get; set; }
        [ForeignKey("Brand")]
        public int BradnId { get; set; }
        public Brand Brand { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size Size { get; set; }
        [ForeignKey("Colour")]
        public int ColourId { get; set; }
        public Colour Colour { get; set; }
    }
}
