using MyCinema.Domain.Models;

namespace MyCinema.Domain.RepositoriesInterfaces.User
{
    public interface IUserReadOnlyRepository
    {
        Task<List<UserModel>> FindAllUsers();
        Task<UserModel> FindUserById(int id);
    }
}
