using AutoMapper;
using Eskitech.Contracts.Pagination;
using Eskitech.Contracts.Products;
using Eskitech.Domain.Exceptions;
using Eskitech.Domain.Products;
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
            try
            {
                var products = _productService.GetAllProducts();
                var productsDto = _mapper.Map<IEnumerable<ProductsGetDto>>(products);
                return Ok(productsDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
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

        [HttpGet("paged")]
        public ActionResult<PagedResultDto<ProductGetDto>> GetAllPaginated([FromQuery] PaginationQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var totalCount = _productService.GetTotalCount();
                var products = _productService.GetAllProductsPaginated(query.Page, query.PageSize);
                var productDtos = _mapper.Map<IEnumerable<ProductGetDto>>(products);

                var pagedResult = new PagedResultDto<ProductGetDto>(productDtos, totalCount, query.Page, query.PageSize);

                return Ok(pagedResult);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<ProductGetDto> CreateProduct(ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var product = _mapper.Map<Product>(productDto);
                _productService.AddProduct(product);

                var createdProductDto = _mapper.Map<ProductGetDto>(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, createdProductDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] ProductUpdateDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existingProduct = _productService.GetProductById(id);

                _mapper.Map(productDto, existingProduct);

                _productService.UpdateProduct(existingProduct);
                return NoContent();
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

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var existingProduct = _productService.GetProductById(id);
                _productService.DeleteProduct(existingProduct);
                return NoContent();
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