using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Get(string id)
        {
            var productDto = _productsService.Get(id);
            if (productDto != null)
                return Ok(productDto);
            return NotFound();
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult Delete(string id)
        {
            try
            {
                _productsService.Delete(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult Put(string id, [FromBody] NewProductDto product)
        {
            try
            {
                _productsService.Update(id, product);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
