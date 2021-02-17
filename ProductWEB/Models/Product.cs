﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWEB.Models
{
    public class Product
    {
        public Product()
        {
            Errors = new List<Errors>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public byte[] Image { get; set; }
        [Range(1,5, ErrorMessage ="La califición del producto debe estar en el rando de {1} a {2}")]
        public double Rating { get; set; }
        public List<Errors> Errors { get; set; }
    }
}
