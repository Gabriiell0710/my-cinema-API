using AutoMapper;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.Film;

namespace MyCinema.Application.Services.Film
{
    public class FilmService : IFIlmService
    {
        private readonly IFilmReadOnlyRepository _filmReadOnlyRepository;
        private readonly IFilmWriteOnlyRepository _filmWriteOnlyRepository;
        private readonly IMapper _mapper;

        public FilmService (IFilmReadOnlyRepository filmReadOnlyRepository, IFilmWriteOnlyRepository filmWriteOnlyRepoditory, IMapper mapper)
        {
            _filmReadOnlyRepository = filmReadOnlyRepository;
            _filmWriteOnlyRepository = filmWriteOnlyRepoditory;
            _mapper = mapper;
        }

        public async Task<List<ResponseRegisteredFilmJson>> GetAll()
        {
            List<FilmModel> filmListModel = await _filmReadOnlyRepository.GetAll();

            var film = _mapper.Map<List<ResponseRegisteredFilmJson>>(filmListModel);

            return film;

        }

        public async Task<ResponseRegisteredFilmJson> GetById(int id)
        {
            FilmModel filmById = await _filmReadOnlyRepository.GetById(id);

            var film = _mapper.Map<ResponseRegisteredFilmJson>(filmById);

            return film;
        }

        public async Task<ResponseRegisteredFilmJson> Add(RequestRegisterFilmJson request)
        {
            var film = _mapper.Map<FilmModel>(request);

            await _filmWriteOnlyRepository.Add(film);

            return new ResponseRegisteredFilmJson
            {
                Title = request.Title,
            };
        }

        public async Task<ResponseRegisteredFilmJson> Update(RequestRegisterFilmJson request, int id)
        {
            var requestToConvert = _mapper.Map<FilmModel>(request);
            FilmModel film = await _filmWriteOnlyRepository.Update(requestToConvert, id);

            var filmUpdated = _mapper.Map<ResponseRegisteredFilmJson>(film);

            return filmUpdated;
            
        }

        public async Task<bool> Delete(int id)
        {
             await _filmWriteOnlyRepository.Delete(id);

            return true;
        }
    }
}
