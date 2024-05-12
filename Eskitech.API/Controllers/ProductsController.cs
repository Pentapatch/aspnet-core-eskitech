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
    public class ProductsController(IProductService productService, IMapper mapper, ILogger<ProductsController> logger) : ControllerBase
    {
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<ProductsController> _logger = logger;

        [HttpGet]
        public ActionResult<IEnumerable<ProductsGetDto>> Get()
        {
            try
            {
                var products = _productService.GetAllProducts();
                var productsDto = _mapper.Map<IEnumerable<ProductsGetDto>>(products);

                _logger.LogInformation("Fetched all products");
                return Ok(productsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching products");
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

                _logger.LogInformation("Fetched product with id {ProductId}", id);
                return Ok(productDto);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogWarning(ex, "Product with id {ProductId} was not found", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching product with id {ProductId}", id);
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
                var productDtos = _mapper.Map<IEnumerable<ProductsGetDto>>(products);

                var pagedResult = new PagedResultDto<ProductsGetDto>(productDtos, totalCount, query.Page, query.PageSize);

                _logger.LogInformation("Fetched paginated products");
                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching paginated products");
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

                _logger.LogInformation("Product with id {ProductId} was created", product.Id);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, createdProductDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a product");
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

                _logger.LogInformation("Product with id {ProductId} was updated", id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogWarning(ex, "Product with id {ProductId} was not found", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating product with id {ProductId}", id);
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
                _logger.LogInformation("Product with id {ProductId} was deleted", id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogWarning(ex, "Product with id {ProductId} was not found", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting product with id {ProductId}", id);
                return StatusCode(500);
            }
        }
    }
}