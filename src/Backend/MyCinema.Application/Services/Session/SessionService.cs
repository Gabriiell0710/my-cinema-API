using AutoMapper;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.Session;

namespace MyCinema.Application.Services.Session
{
    public class SessionService : ISessionService
    {
        private readonly ISessionReadOnlyRepository _sessionReadOnlyRepository;
        private readonly ISessionWriteOnlyRepository _sessionWriteOnlyRepository;
        private readonly IMapper _mapper;

        public SessionService(ISessionReadOnlyRepository sessionReadOnlyRepository, ISessionWriteOnlyRepository sessionWriteOnlyRepository, 
            IMapper mapper)
        {
            _sessionReadOnlyRepository = sessionReadOnlyRepository;
            _sessionWriteOnlyRepository = sessionWriteOnlyRepository;
            _mapper = mapper;
        }


        public async Task<List<ResponseRegisteredSessionJson>> GetAll()
        {
            List<SessionModel> sessionList = await _sessionReadOnlyRepository.GetAll();
            var sessions = _mapper.Map<List<ResponseRegisteredSessionJson>>(sessionList);
            return sessions;
        }

        public async Task<ResponseRegisteredSessionJson> GetById(int id)
        {
            SessionModel sessionById = await _sessionReadOnlyRepository.GetById(id);
            var session = _mapper.Map<ResponseRegisteredSessionJson>(sessionById);
            return session;
        }
        public async Task<ResponseRegisteredSessionJson> Add(RequestRegisterSessionJson request)
        {
            var session = _mapper.Map<SessionModel>(request);
           var result = await  _sessionWriteOnlyRepository.Add(session);

            var sessionResponse = _mapper.Map<ResponseRegisteredSessionJson>(result);

            return sessionResponse;
        }
        public async Task<ResponseRegisteredSessionJson> Update(RequestRegisterSessionJson request, int id)
        {
            var sessionToConvert = _mapper.Map<SessionModel>(request);
            SessionModel sessionModel = await _sessionWriteOnlyRepository.Update(sessionToConvert, id);
            var sessionUpdated = _mapper.Map<ResponseRegisteredSessionJson>(sessionModel);

            return sessionUpdated;
        }

        public async Task<bool> Delete(int id)
        {
            await _sessionWriteOnlyRepository.Delete(id);
            return true;
        }
 
    }
}
