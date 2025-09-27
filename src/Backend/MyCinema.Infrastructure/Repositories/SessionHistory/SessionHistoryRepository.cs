using Microsoft.EntityFrameworkCore;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.SessionHistory;
using MyCinema.Infrastructure.DataAcess;

namespace MyCinema.Infrastructure.Repositories.SessionHistory
{
    public class SessionHistoryRepository : ISessionHistoryReadOnlyRepository, ISessionHistoryWriteOnlyRepository
    {

        private readonly MyCinemaDbContex _dbContext;

        public SessionHistoryRepository(MyCinemaDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SessionHistoryModel>> FindAllSessionsHistory()
        {
            return await _dbContext.SessionsHistory.ToListAsync();
        }

        public async Task<SessionHistoryModel> FindSessionHistoryById(int id)
        {
            return await _dbContext.SessionsHistory.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<SessionHistoryModel> AddSessionHistory(SessionHistoryModel sessionHistory)
        {
            await _dbContext.SessionsHistory.AddAsync(sessionHistory);
            await _dbContext.SaveChangesAsync();
            return sessionHistory;
        }

        public async Task<SessionHistoryModel> UpdateSessionHistory(SessionHistoryModel sessionHistory, int id)
        {
            SessionHistoryModel sessionModel = await FindSessionHistoryById(id);
            if (sessionModel == null)
            {
                throw new Exception($"O histórico de sessão com o Id: {id} não existe no banco de dados.");
            }

            sessionModel.UserId = sessionHistory.UserId;
            sessionModel.SessionId = sessionHistory.SessionId;
            sessionModel.Status = sessionHistory.Status;

            _dbContext.SessionsHistory.Update(sessionModel);
            await _dbContext.SaveChangesAsync();
            return sessionModel;
        }

        public async Task<bool> DeleteSessionHistory(int id)
        {
            SessionHistoryModel sessionModel = await FindSessionHistoryById(id);
            if (sessionModel == null)
            {
                throw new Exception($"O histórico de sessão com o Id: {id} não existe no banco de dados.");
            }
            _dbContext.SessionsHistory.Remove(sessionModel);
            await _dbContext.SaveChangesAsync();
            return true;
        }
  
    }
}
