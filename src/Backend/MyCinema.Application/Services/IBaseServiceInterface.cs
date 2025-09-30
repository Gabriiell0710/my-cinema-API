namespace MyCinema.Application.Services
{
    public interface IBaseServiceInterface<TEntity,ZEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Add(ZEntity entity);
        Task<TEntity> Update(ZEntity entity,int id);
        Task<bool> Delete(int id);
    }
}
