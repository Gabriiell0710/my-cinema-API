using MyCinema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Domain.RepositoriesInterfaces.Film
{
    public interface IFilmWriteOnlyRepository
    {
        Task<FilmModel> AddFilm(FilmModel film);
        Task<FilmModel> UpdateFilm(FilmModel film, int id);
        Task<bool> DeleteFilm(int id);
    }
}
