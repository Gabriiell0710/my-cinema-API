using MyCinema.Domain.Models;

namespace MyCinema.Domain.RepositoriesInterfaces.SessionHistory
{
    public interface ISessionHistoryReadOnlyRepository
    {
        Task<List<SessionHistoryModel>> FindAllSessionsHistory();
        Task<SessionHistoryModel> FindSessionHistoryById(int id);
    }
}
