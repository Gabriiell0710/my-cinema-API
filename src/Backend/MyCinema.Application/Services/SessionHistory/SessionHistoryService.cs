using AutoMapper;
using MyCinema.Communication.Enums;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.SessionHistory;

namespace MyCinema.Application.Services.SessionHistory
{
    public class SessionHistoryService : ISessionHistoryService
    {
        private readonly ISessionHistoryReadOnlyRepository _sessionHistoryReadOnlyRepository;
        private readonly ISessionHistoryWriteOnlyRepository _sessionHistoryWriteOnlyRepository;
        private IMapper _mapper;


        public SessionHistoryService(ISessionHistoryReadOnlyRepository sessionHistoryReadOnlyRepository, ISessionHistoryWriteOnlyRepository sessionHistoryWriteOnlyRepository, IMapper mapper)
        {
            _sessionHistoryReadOnlyRepository = sessionHistoryReadOnlyRepository;
            _sessionHistoryWriteOnlyRepository = sessionHistoryWriteOnlyRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseRegisteredSessionHistoryJson>> GetAll()
        {
            List<SessionHistoryModel> sessionHistoryModel = await _sessionHistoryReadOnlyRepository.GetAll();
            var response = _mapper.Map<List<ResponseRegisteredSessionHistoryJson>>(sessionHistoryModel);
            return response;
        }

        public async Task<ResponseRegisteredSessionHistoryJson> GetById(int id)
        {
            var sessionHistoryModel = await _sessionHistoryReadOnlyRepository.GetById(id);
            var response = _mapper.Map<ResponseRegisteredSessionHistoryJson>(sessionHistoryModel);
            return response;
        }
        public async Task<ResponseRegisteredSessionHistoryJson> Add(RequestRegisterSessionHistoryJson request)
        {
            SessionHistoryModel requestToModel = _mapper.Map<SessionHistoryModel>(request);
            await _sessionHistoryWriteOnlyRepository.Add(requestToModel);

            return new ResponseRegisteredSessionHistoryJson
            {
                SessionId = request.SessionId,
                UserId = request.UserId,
            };
        }

        public Task<ResponseRegisteredSessionHistoryJson> Update(RequestRegisterSessionHistoryJson entity, int id)
        {
            //este método não será utilizado. Para atualizar o Status do histórico da sessão será utilizado outro método.
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            await _sessionHistoryWriteOnlyRepository.Delete(id);
            return true;
        }

        public async void UpdateSessionHistory(SessionStatusEnum status, int id)
        {

        }

    }
}
