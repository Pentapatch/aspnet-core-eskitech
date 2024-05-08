using AutoMapper;
using Eskitech.Contracts.Products;
using Eskitech.Domain.Exceptions;
using Eskitech.Entities.Products;
using Microsoft.AspNetCore.Mvc;

namespace Eskitech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService, IMapper mapper) : ControllerBase
    {
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public ActionResult<IEnumerable<ProductsGetDto>> Get()
        {
            var products = _productService.GetAllProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductsGetDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductGetDto> GetById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                var productDto = _mapper.Map<ProductGetDto>(product);
                return Ok(productDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}