namespace Eskitech.Contracts.Categories
{
    public class CategoryGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}