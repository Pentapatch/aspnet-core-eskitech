using Eskitech.Entities.Bases;

namespace Eskitech.Contracts.Lookup
{
    public class LookupDto<TEntity> where TEntity : Entity
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}