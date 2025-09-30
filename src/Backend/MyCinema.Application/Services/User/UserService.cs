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

        public async Task<List<ResponseRegisteredUserJson>> GetAll()
        {
            List<UserModel> user = await _userReadOnlyRepository.GetAll();
            return _mapper.Map<List<ResponseRegisteredUserJson>>(user);
        }

        public async Task<ResponseRegisteredUserJson> GetById(int id)
        {
            var userById = await _userReadOnlyRepository.GetById(id);
            return _mapper.Map<ResponseRegisteredUserJson>(userById);
        }

        public async Task<ResponseRegisteredUserJson> Add(RequestRegisterUserJson request)
        {
            var user = _mapper.Map<UserModel>(request);
           var userCreated = await _userWrireOnlyRepository.Add(user);

           return _mapper.Map<ResponseRegisteredUserJson>(userCreated);

        }

        public async Task<ResponseRegisteredUserJson> Update(RequestRegisterUserJson request, int id)
        {
            var userToUpdate = _mapper.Map<UserModel>(request);
            UserModel userToConvert = await _userWrireOnlyRepository.Update(userToUpdate, id);
            var userUpdated = _mapper.Map<ResponseRegisteredUserJson>(userToConvert);

            return userUpdated;
        }

        public async Task<bool> Delete(int id)
        {
            await _userWrireOnlyRepository.Delete(id);
            return true;
        }

        

        
    }
}
