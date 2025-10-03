using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.UserHistory
{
    public interface IUserHistoryService : IBaseServiceInterface<ResponseRegisteredUserHistoryJson, RequestRegisterUserHistoryJson>
    {
    }
}
