using MyCinema.Domain.Models;
using MyCinema.Communication.Requests;

namespace MyCinema.Domain.RepositoriesInterfaces.Film
{
    public interface IFilmReadOnlyRepository
    {
        Task<List<FilmModel>> FindAllFilms();
        Task<FilmModel> FindFilmById(int id);

    }
}
