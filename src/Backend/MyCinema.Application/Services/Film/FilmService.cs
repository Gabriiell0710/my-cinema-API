using AutoMapper;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<ResponseRegisteredFilmJson>> FindAllFilms()
        {
            List<FilmModel> filmListModel = await _filmReadOnlyRepository.FindAllFilms();

            var film = _mapper.Map<List<ResponseRegisteredFilmJson>>(filmListModel);

            return film;

        }

        public async Task<ResponseRegisteredFilmJson> FindFilmById(int id)
        {
            FilmModel filmById = await _filmReadOnlyRepository.FindFilmById(id);

            var film = _mapper.Map<ResponseRegisteredFilmJson>(filmById);

            return film;
        }

        public async Task<ResponseRegisteredFilmJson> AddFilm(RequestRegisterFilmJson request)
        {
            var film = _mapper.Map<FilmModel>(request);

            await _filmWriteOnlyRepository.AddFilm(film);

            return new ResponseRegisteredFilmJson
            {
                Title = request.Title,
            };
        }

        public async Task<ResponseRegisteredFilmJson> UpdateFilm(RequestRegisterFilmJson request, int id)
        {
            var requestToConvert = _mapper.Map<FilmModel>(request);
            FilmModel film = await _filmWriteOnlyRepository.UpdateFilm(requestToConvert, id);

            var filmUpdated = _mapper.Map<ResponseRegisteredFilmJson>(film);

            return filmUpdated;
            
        }

        public async Task<bool> DeleteFilm(int id)
        {
             await _filmWriteOnlyRepository.DeleteFilm(id);

            return true;
        }
    }
}
