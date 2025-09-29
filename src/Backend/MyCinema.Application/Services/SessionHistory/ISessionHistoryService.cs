using MyCinema.Communication.Enums;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.SessionHistory
{
    public interface ISessionHistoryService
    {
        Task<List<ResponseRegisteredSessionHistoryJson>> FindAllSessionHistories();
        Task<ResponseRegisteredSessionHistoryJson> FindSessionHistoryById(int id);
        Task<ResponseRegisteredSessionHistoryJson> AddSessionHistory(RequestRegisterSessionHistoryJson request);
        Task<ResponseRegisteredSessionHistoryJson> UpdateSessionHistory(SessionStatusEnum status, int id);
        Task<bool> DeleteSessionHistory(int id);
    }
}
