using Eskitech.Entities.Bases;

namespace Eskitech.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(int id);
        void Update(TEntity entity);
    }
}