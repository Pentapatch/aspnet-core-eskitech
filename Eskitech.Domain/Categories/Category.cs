using Eskitech.Domain.Bases;

#nullable disable

namespace Eskitech.Domain.Categories
{
    public class Category : AuditedEntity
    {
        public string Name { get; set; }
    }
}