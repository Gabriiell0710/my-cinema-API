using MyCinema.Domain.Models;

namespace MyCinema.Domain.RepositoriesInterfaces
{
    public interface IWriteOnlyBaseRepositoryInterface<TEntity> where TEntity : ModelBase
    {
        Task<TEntity> Add (TEntity entity);
        Task<TEntity> Update (TEntity entity, int id);
        Task<bool> Delete (int id);
    }
}
