using Eskitech.Domain.Exceptions;
using Eskitech.Entities.Categories;
using Eskitech.Infrastructure.Repositories;

namespace Eskitech.Domain.Categories
{
    public class CategoryService(IBaseRepository<Category> categoryRepository) : ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryRepository = categoryRepository;

        public IEnumerable<Category> GetAllCategories() =>
            _categoryRepository.GetAll();

        public IEnumerable<Category> GetAllCategoriesPaginated(int page, int pageSize) =>
            _categoryRepository.GetAllPaginated(page, pageSize);

        public int GetTotalCount() =>
            _categoryRepository.GetTotalCount();

        public Category GetCategoryById(int id) =>
            _categoryRepository.GetById(id)
                ?? throw new EntityNotFoundException($"Could not find a category with an Id of '{id}'.");

        public void AddCategory(Category category) =>
            _categoryRepository.Add(category);

        public void UpdateCategory(Category category) =>
            _categoryRepository.Update(category);

        public void DeleteCategory(Category category) =>
            _categoryRepository.Delete(category);
    }
}