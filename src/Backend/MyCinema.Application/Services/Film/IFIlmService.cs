using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.Film
{
    public interface IFIlmService
    {
        public Task<ResponseRegisteredFilmJson> AddFilm(RequestRegisterFilmJson request);

        public Task<List<ResponseRegisteredFilmJson>> FindAllFilms();

        public Task<ResponseRegisteredFilmJson> FindFilmById(int id);

        public Task<ResponseRegisteredFilmJson> UpdateFilm(RequestRegisterFilmJson request, int id);
        public Task<bool> DeleteFilm(int id);
    }
}
