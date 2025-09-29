using MyCinema.Domain.Models;
using MyCinema.Communication.Requests;

namespace MyCinema.Domain.RepositoriesInterfaces.Film
{
    public interface IFilmReadOnlyRepository : IReadOnlyBaseRepositoryInterface<FilmModel>
    {
    }
}
