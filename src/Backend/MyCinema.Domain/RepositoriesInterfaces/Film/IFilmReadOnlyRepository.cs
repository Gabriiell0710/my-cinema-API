using MyCinema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Domain.RepositoriesInterfaces.Film
{
    public interface IFilmReadOnlyRepository
    {
        Task<List<FilmModel>> FindAllFilms();
        Task<FilmModel> FindFilmById(int id);

    }
}
