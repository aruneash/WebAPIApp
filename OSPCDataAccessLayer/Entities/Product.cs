using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OSPCDataAccessLayer.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int StockAvailability { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Image Image { get; set; }
        public int ImageId { get; set; }
    }
}
