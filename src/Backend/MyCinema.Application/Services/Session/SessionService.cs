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


        public async Task<List<ResponseRegisteredSessionJson>> FindAllSessions()
        {
            List<SessionModel> sessionList = await _sessionReadOnlyRepository.FindAllSessions();
            var sessions = _mapper.Map<List<ResponseRegisteredSessionJson>>(sessionList);
            return sessions;
        }

        public async Task<ResponseRegisteredSessionJson> FindSessionById(int id)
        {
            SessionModel sessionById = await _sessionReadOnlyRepository.FindSessionById(id);
            var session = _mapper.Map<ResponseRegisteredSessionJson>(sessionById);
            return session;
        }
        public async Task<ResponseRegisteredSessionJson> AddSession(RequestRegisterSessionJson request)
        {
            var session = _mapper.Map<SessionModel>(request);
            await  _sessionWriteOnlyRepository.AddSession(session);

            return new ResponseRegisteredSessionJson
            {
                DateAndTime = request.DateAndTime,
            };
        }
        public async Task<ResponseRegisteredSessionJson> UpdateSession(RequestRegisterSessionJson request, int id)
        {
            var sessionToConvert = _mapper.Map<SessionModel>(request);
            SessionModel sessionModel = await _sessionWriteOnlyRepository.UpdateSession(sessionToConvert, id);
            var sessionUpdated = _mapper.Map<ResponseRegisteredSessionJson>(sessionModel);

            return sessionUpdated;
        }

        public async Task<bool> DeleteSession(int id)
        {
            await _sessionWriteOnlyRepository.DeleteSession(id);
            return true;
        }
 
    }
}
