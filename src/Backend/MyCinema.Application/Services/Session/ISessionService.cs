using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.Session
{
    public interface ISessionService : IBaseServiceInterface<ResponseRegisteredSessionJson,RequestRegisterSessionJson>
    {
        Task<List<ResponseRegisteredSessionJson>> GetAll();
        Task<ResponseRegisteredSessionJson> GetById(int id);
        Task<ResponseRegisteredSessionJson> Add(RequestRegisterSessionJson request);
        Task<ResponseRegisteredSessionJson> Update(RequestRegisterSessionJson request, int id);
        Task<bool> Delete(int id);

    }
}
