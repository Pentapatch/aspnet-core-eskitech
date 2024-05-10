using AutoMapper;
using Eskitech.Contracts.Categories;
using Eskitech.Contracts.Pagination;
using Eskitech.Domain.Categories;
using Eskitech.Domain.Exceptions;
using Eskitech.Entities.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Eskitech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService, IMapper mapper, ILogger<CategoriesController> logger) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CategoriesController> _logger = logger;

        [HttpGet]
        public ActionResult<IEnumerable<CategoriesGetDto>> GetAll()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();
                var categoryDtos = _mapper.Map<IEnumerable<CategoriesGetDto>>(categories);

                _logger.LogInformation("Fetched all categories");
                return Ok(categoryDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryGetDto> GetById(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);
                var categoryDto = _mapper.Map<CategoryGetDto>(category);

                _logger.LogInformation("Fetched category with id {CategoryId}", id);
                return Ok(categoryDto);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogWarning(ex, "Category with id {CategoryId} was not found", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching category with id {CategoryId}", id);
                return StatusCode(500);
            }
        }
        
        [HttpGet("paged")]
        public ActionResult<PagedResultDto<CategoriesGetDto>> GetAllPaginated([FromQuery] PaginationQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var totalCount = _categoryService.GetTotalCount();
                var categories = _categoryService.GetAllCategoriesPaginated(query.Page, query.PageSize);
                var categoryDtos = _mapper.Map<IEnumerable<CategoriesGetDto>>(categories);

                var pagedResult = new PagedResultDto<CategoriesGetDto>(categoryDtos, totalCount, query.Page, query.PageSize);

                _logger.LogInformation("Fetched paginated categories");
                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching paginated categories");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<CategoryGetDto> Create(CategoryCreateDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                _categoryService.AddCategory(category);

                var createdCategoryDto = _mapper.Map<CategoryGetDto>(category);

                _logger.LogInformation("Category with id {CategoryId} was created", category.Id);
                return CreatedAtAction(nameof(GetById), new { id = category.Id }, createdCategoryDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a category");
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CategoryUpdateDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existingCategory = _categoryService.GetCategoryById(id);

                _mapper.Map(categoryDto, existingCategory);

                _categoryService.UpdateCategory(existingCategory);

                _logger.LogInformation("Category with id {CategoryId} was updated", id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogWarning(ex, "Category with id {CategoryId} was not found", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating category with id {CategoryId}", id);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var existingCategory = _categoryService.GetCategoryById(id);
                _categoryService.DeleteCategory(existingCategory);
                _logger.LogInformation("Category with id {CategoryId} was deleted", id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogWarning(ex, "Category with id {CategoryId} was not found", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting categories with id {CategoryId}", id);
                return StatusCode(500);
            }
        }
    }
}