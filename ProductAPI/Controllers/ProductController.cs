using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Models.DTO;
using ProductAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAllProduct()
        {
            var product = productRepository.GetallProduct();
            return Ok(mapper.Map<List<ProductDTO>>(product));
        }

        [HttpGet("{id}", Name = "GetProduct")]

        public IActionResult GetProduct(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null) return NotFound();
            return Ok(mapper.Map<ProductDTO>(product));
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (productRepository.ProductoExists(productDTO.Name))
            {
                ModelState.AddModelError(string.Empty, $"ya existe un producto con el nombre{productDTO.Name}");
                return StatusCode(404, ModelState);
            }

            var product = mapper.Map<Product>(productDTO);

            if (!productRepository.CreateProduct(product))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al guardar el producto {productDTO.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }
    }
}
