using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.User
{
    public interface IUserService
    {
        Task<List<ResponseRegisteredUserJson>> FindAllUsers();
        Task<ResponseRegisteredUserJson> FindUserById(int id);
        Task<ResponseRegisteredUserJson> AddUser(RequestRegisterUserJson request);
        Task<ResponseRegisteredUserJson> UpdateUser(RequestRegisterUserJson request, int id);
        Task<bool> DeleteUser(int id);
    }
}
