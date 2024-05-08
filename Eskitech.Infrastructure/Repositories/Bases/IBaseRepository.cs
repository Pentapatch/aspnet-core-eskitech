using Eskitech.Entities.Bases;

namespace Eskitech.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllPaginated(int page, int pageSize);
        TEntity? GetById(int id);
        int GetTotalCount();
        void Update(TEntity entity);
    }
}