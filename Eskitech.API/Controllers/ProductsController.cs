using AutoMapper;
using Eskitech.Contracts.Pagination;
using Eskitech.Contracts.Products;
using Eskitech.Domain.Exceptions;
using Eskitech.Domain.Products;
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
    }
}