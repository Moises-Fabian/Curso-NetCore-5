using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Precio { get; set; }

        public DateTime CreateDate { get; set; }

        public byte[] Image { get; set; }

        public double Rating { get; set; }
    }
}
