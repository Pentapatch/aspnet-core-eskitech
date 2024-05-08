namespace Eskitech.Entities.Bases
{
    public abstract class AuditedEntity : Entity
    {
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}