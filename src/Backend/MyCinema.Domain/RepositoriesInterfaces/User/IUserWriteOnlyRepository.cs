using MyCinema.Domain.Models;

namespace MyCinema.Domain.RepositoriesInterfaces.User
{
    public interface IUserWriteOnlyRepository
    {
        Task<UserModel> AddUser (UserModel user);
        Task<UserModel> UpdateUser (UserModel user, int id);
        Task<bool> DeleteUser (int id);
    }
}
