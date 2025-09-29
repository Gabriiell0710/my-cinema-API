using MyCinema.Domain.Models;

namespace MyCinema.Domain.RepositoriesInterfaces
{
    public interface IReadOnlyBaseRepositoryInterface<TEntity> where TEntity : ModelBase
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
