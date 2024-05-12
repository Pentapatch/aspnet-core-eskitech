using Eskitech.Entities.Categories;

namespace Eskitech.Domain.Categories
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetAllCategoriesPaginated(int page, int pageSize);
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        int GetTotalCount();
    }
}