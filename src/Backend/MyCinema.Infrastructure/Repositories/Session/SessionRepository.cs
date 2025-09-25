using Microsoft.EntityFrameworkCore;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.Session;
using MyCinema.Infrastructure.DataAcess;

namespace MyCinema.Infrastructure.Repositories.Session
{
    public class SessionRepository : ISessionReadOnlyRepository, ISessionWriteOnlyRepository
    {

        private readonly MyCinemaDbContex _DbContext;

        public SessionRepository(MyCinemaDbContex context)
        {
            _DbContext = context;
        }

        public async Task<List<SessionModel>> FindAllSessions()
        {
            return await _DbContext.Sessions
                .Include(s => s.Room)
                .Include(s => s.Film)
                .ToListAsync();
        }

        public async Task<SessionModel> FindSessionById(int id)
        {
            return await _DbContext.Sessions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SessionModel> AddSession(SessionModel session)
        {
             await _DbContext.Sessions.AddAsync(session);
             await _DbContext.SaveChangesAsync();
             return session;

        }

        public async Task<SessionModel> UpdateSession(SessionModel session, int id)
        {
            SessionModel sessionModel = await FindSessionById(id);
            if (sessionModel == null) 
            {
                throw new Exception($"A sessão com o Id: {id} não existe no banco de dados.");
            }
             _DbContext.Sessions.Update(sessionModel);
            await _DbContext.SaveChangesAsync();
            return sessionModel;
        }

        public async Task<bool> DeleteSession(int id)
        {
            SessionModel sessionModel = await FindSessionById(id);
            if (sessionModel == null)
            {
                throw new Exception($"A sessão com o Id {id} não existe no banco de dados.");
            }
             _DbContext.Sessions.Remove(sessionModel);
            await _DbContext.SaveChangesAsync();

            return true;
        }
    }
}
