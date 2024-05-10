using System.ComponentModel.DataAnnotations;

namespace Eskitech.Contracts.Categories
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}