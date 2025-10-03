using AutoMapper;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.UserHistory;

namespace MyCinema.Application.Services.UserHistory
{
    public class UserHistoryService : IUserHistoryService
    {

        private readonly IUserHistoryReadOnlyRepository _userHistoryReadOnlyRepository;
        private readonly IUserHistoryWriteOnlyRepository _userHistoryWriteOnlyRepository;
        private readonly IMapper _mapper;

        public UserHistoryService(IUserHistoryReadOnlyRepository userHistoryReadOnlyRepository, 
            IUserHistoryWriteOnlyRepository userHistoryWriteOnlyRepository, IMapper mapper)
        {
            _userHistoryReadOnlyRepository = userHistoryReadOnlyRepository;
            _userHistoryWriteOnlyRepository = userHistoryWriteOnlyRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseRegisteredUserHistoryJson>> GetAll()
        {
            List<UserHistoryModel> list = await _userHistoryReadOnlyRepository.GetAll();
            return _mapper.Map<List<ResponseRegisteredUserHistoryJson>>(list);
        }

        public async Task<ResponseRegisteredUserHistoryJson> GetById(int id)
        {
            UserHistoryModel history = await _userHistoryReadOnlyRepository.GetById(id);
            return _mapper.Map<ResponseRegisteredUserHistoryJson>(history);
        }

        public async Task<ResponseRegisteredUserHistoryJson> Add(RequestRegisterUserHistoryJson request)
        {
            var history = _mapper.Map<UserHistoryModel>(request);
           var response = await _userHistoryWriteOnlyRepository.Add(history);
            return _mapper.Map<ResponseRegisteredUserHistoryJson>(response);
        }


        //métodos ainda não implementados//
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        
        public Task<ResponseRegisteredUserHistoryJson> Update(RequestRegisterUserHistoryJson entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
