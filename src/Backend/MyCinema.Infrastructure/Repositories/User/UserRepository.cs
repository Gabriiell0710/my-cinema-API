using Microsoft.EntityFrameworkCore;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.User;
using MyCinema.Infrastructure.DataAcess;

namespace MyCinema.Infrastructure.Repositories.User
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly MyCinemaDbContex _DbContext;

        public UserRepository(MyCinemaDbContex dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _DbContext.Users.ToListAsync();
        }

        public async Task<UserModel> FindUserById(int id)
        {
            return await _DbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _DbContext.Users.AddAsync(user);
            await _DbContext.SaveChangesAsync();
            return user;
            
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            var userToUpdate = await FindUserById(id);
            if(userToUpdate == null)
            {
                throw new Exception($"O usuário com o ID {id} não foi encontrado no banco de dados");
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            userToUpdate.Profile = user.Profile;

            _DbContext.Users.Update(userToUpdate);
            await _DbContext.SaveChangesAsync();

            return userToUpdate;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var userToDelete = await FindUserById(id);
            if (userToDelete == null)
            {
                throw new Exception($"O usuário com o ID {id} não foi encontrado no banco de dados");
            }
            _DbContext.Users.Remove(userToDelete);
            return true;
        }
        
    }
}
