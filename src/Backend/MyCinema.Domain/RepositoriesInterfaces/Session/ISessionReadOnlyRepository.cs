using MyCinema.Domain.Models;

namespace MyCinema.Domain.RepositoriesInterfaces.Session
{
    public interface ISessionReadOnlyRepository
    {
        Task<List<SessionModel>> FindAllSessions();
        Task<SessionModel> FindSessionById(int id);
    }
}
