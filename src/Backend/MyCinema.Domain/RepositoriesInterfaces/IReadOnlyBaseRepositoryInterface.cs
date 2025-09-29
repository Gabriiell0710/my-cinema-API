namespace MyCinema.Domain.RepositoriesInterfaces
{
    public interface IReadOnlyBaseRepositoryInterface<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
