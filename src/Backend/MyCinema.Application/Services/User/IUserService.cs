using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.User
{
    public interface IUserService : IBaseServiceInterface<ResponseRegisteredUserJson, RequestRegisterUserJson>
    {
        Task<List<ResponseRegisteredUserJson>> GetAll();
        Task<ResponseRegisteredUserJson> GetById(int id);
        Task<ResponseRegisteredUserJson> Add(RequestRegisterUserJson request);
        Task<ResponseRegisteredUserJson> Update(RequestRegisterUserJson request, int id);
        Task<bool> Delete(int id);
    }
}
