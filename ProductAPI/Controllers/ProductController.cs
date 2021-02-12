using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]

        public IActionResult GetProduct(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null) return NotFound();
            return Ok(mapper.Map<ProductDTO>(product));
        }

    }
}
