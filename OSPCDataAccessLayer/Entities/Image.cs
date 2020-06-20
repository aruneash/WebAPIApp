using System;
using System.Collections.Generic;
using System.Text;

namespace OSPCDataAccessLayer.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
