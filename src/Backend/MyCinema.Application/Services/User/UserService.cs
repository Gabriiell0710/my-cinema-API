using AutoMapper;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.User;

namespace MyCinema.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWrireOnlyRepository;
        private readonly IMapper _mapper;

        public UserService(IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository userWriteOnlyRepository, IMapper mapper)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWrireOnlyRepository = userWriteOnlyRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseRegisteredUserJson>> FindAllUsers()
        {
            List<UserModel> user = await _userReadOnlyRepository.FindAllUsers();
            return _mapper.Map<List<ResponseRegisteredUserJson>>(user);
        }

        public async Task<ResponseRegisteredUserJson> FindUserById(int id)
        {
            var userById = await _userReadOnlyRepository.FindUserById(id);
            return _mapper.Map<ResponseRegisteredUserJson>(userById);
        }

        public async Task<ResponseRegisteredUserJson> AddUser(RequestRegisterUserJson request)
        {
            var user = _mapper.Map<UserModel>(request);
           var userCreated = await _userWrireOnlyRepository.AddUser(user);

           return _mapper.Map<ResponseRegisteredUserJson>(userCreated);

        }

        public async Task<ResponseRegisteredUserJson> UpdateUser(RequestRegisterUserJson request, int id)
        {
            var userToUpdate = _mapper.Map<UserModel>(request);
            UserModel userToConvert = await _userWrireOnlyRepository.UpdateUser(userToUpdate, id);
            var userUpdated = _mapper.Map<ResponseRegisteredUserJson>(userToConvert);

            return userUpdated;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await _userWrireOnlyRepository.DeleteUser(id);
            return true;
        }

        

        
    }
}
