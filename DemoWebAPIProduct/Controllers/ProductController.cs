using DemoWebAPI.DTO;
using FakeDAL.Entities;
using FakeDAL.Interfaces;
using FakeDAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DemoWebAPI.DTO.CreateProductDTO;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ProductListDTO))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public IActionResult GetAll()
        {
            var products = _productRepository.GetAll().ToList();

            var result = new ProductListDTO
            {
                Count = products.Count,
                TotalPrice = products.Sum(p => p.Prix),
                Products = products.Select(p => new ProductSummaryDTO(p))
            };

            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public IActionResult GetById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return NotFound(new { message = $"Product #{id} not found" });

            return Ok(new ProductDTO(product));
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProductDTO))]
        [Produces("application/json")]
        public IActionResult Create([FromBody] CreateProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productAdded = _productRepository.Add(CreateProductDTO.ToEntity(productDto));
            return CreatedAtAction(nameof(GetById), new { id = productAdded.Id }, new ProductDTO(productAdded));
        }


        [HttpGet("min-price/{price}")]
        [ProducesResponseType(200, Type = typeof(ProductListDTO))]
        [Produces("application/json")]
        public IActionResult GetByMinPrice(double price)
        {
            var products = _productRepository.GetByMinPrice(price).ToList();

            var result = new ProductListDTO
            {
                Count = products.Count,
                TotalPrice = products.Sum(p => p.Prix),
                Products = products.Select(p => new ProductSummaryDTO(p))
            };

            return Ok(result);
        }

        [HttpGet("in-stock/{inStock}")]
        [ProducesResponseType(200, Type = typeof(ProductListDTO))]
        [Produces("application/json")]
        public IActionResult GetByInStock(bool inStock)
        {
            var products = _productRepository.GetByInStock(inStock).ToList();

            var result = new ProductListDTO
            {
                Count = products.Count,
                TotalPrice = products.Sum(p => p.Prix),
                Products = products.Select(p => new ProductSummaryDTO(p))
            };

            return Ok(result);
        }


    }
}
