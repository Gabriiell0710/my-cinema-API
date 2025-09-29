namespace MyCinema.Domain.RepositoriesInterfaces
{
    public interface IWriteOnlyBaseRepositoryInterface<TEntity>
    {
        Task<TEntity> Add (TEntity entity);
        Task<TEntity> Update (TEntity entity, int id);
        Task<TEntity> Delete (int id);
    }
}
