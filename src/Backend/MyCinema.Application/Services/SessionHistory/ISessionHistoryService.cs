using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.SessionHistory
{
    public interface ISessionHistoryService : IBaseServiceInterface<ResponseRegisteredSessionHistoryJson, RequestRegisterSessionHistoryJson>
    {
        Task<List<ResponseRegisteredSessionHistoryJson>> GetAll();
        Task<ResponseRegisteredSessionHistoryJson> GetById(int id);
        Task<ResponseRegisteredSessionHistoryJson> Add(RequestRegisterSessionHistoryJson request);
        Task<ResponseRegisteredSessionHistoryJson> Update(RequestRegisterSessionHistoryJson request, int id);
        Task<bool> Delete(int id);
    }
}
