using MyCinema.Domain.Models;

namespace MyCinema.Domain.RepositoriesInterfaces.Session
{
    public interface ISessionWriteOnlyRepository
    {
        Task<SessionModel> AddSession (SessionModel session);
        Task<SessionModel> UpdateSession (SessionModel session, int id);
        Task<bool> DeleteSession(int id);
    }
}
