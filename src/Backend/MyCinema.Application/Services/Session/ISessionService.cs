using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.Session
{
    public interface ISessionService
    {
        Task<List<ResponseRegisteredSessionJson>> FindAllSessions();
        Task<ResponseRegisteredSessionJson> FindSessionById(int id);
        Task<ResponseRegisteredSessionJson> AddSession(RequestRegisterSessionJson request);
        Task<ResponseRegisteredSessionJson> UpdateSession(RequestRegisterSessionJson request, int id);
        Task<bool> DeleteSession(int id);

    }
}
