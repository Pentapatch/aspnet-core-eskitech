using System.ComponentModel.DataAnnotations;

namespace Eskitech.Contracts.Categories
{
    public class CategoryUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}