using MyCinema.Domain.Models;

namespace MyCinema.Domain.RepositoriesInterfaces.SessionHistory
{
    public interface ISessionHistoryWriteOnlyRepository
    {
      Task<SessionHistoryModel> AddSessionHistory(SessionHistoryModel sessionHistory);
      Task<SessionHistoryModel> UpdateSessionHistory(SessionHistoryModel sessionHistory, int id);
      Task<bool> DeleteSessionHistory(int id);
    }
}
