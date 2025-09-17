using MyCinema.Domain.RepositoriesInterfaces.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Infrastructure.Repositories.Film
{
    public class FilmRepository : IFilmReadOnlyRepository, IFilmWriteOnlyRepository
    {
    }
}
