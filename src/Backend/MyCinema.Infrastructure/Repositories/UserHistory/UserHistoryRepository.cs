using Microsoft.EntityFrameworkCore;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.UserHistory;
using MyCinema.Infrastructure.DataAcess;

namespace MyCinema.Infrastructure.Repositories.UserHistory
{
    public class UserHistoryRepository : IUserHistoryReadOnlyRepository, IUserHistoryWriteOnlyRepository
    {
        private readonly MyCinemaDbContex _dbContext;


        public UserHistoryRepository(MyCinemaDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserHistoryModel>> GetAll()
        {
            return await _dbContext.UsersHistory.ToListAsync();
        }

        public async Task<UserHistoryModel> GetById(int id)
        {
            return await _dbContext.UsersHistory.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserHistoryModel> Add(UserHistoryModel entity)
        {
            await _dbContext.UsersHistory.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public Task<UserHistoryModel> Update(UserHistoryModel entity, int id)
        {
            throw new NotImplementedException();
            //Sem necessidade de uso.
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
            //Sem necessidade de uso.
        }

    }
}
