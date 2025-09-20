using Microsoft.EntityFrameworkCore;
using MyCinema.Communication.Requests;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.Film;
using MyCinema.Infrastructure.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Infrastructure.Repositories.Film
{
    public class FilmRepository : IFilmReadOnlyRepository, IFilmWriteOnlyRepository
    {
        private readonly MyCinemaDbContex _dbContext;

        public FilmRepository(MyCinemaDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FilmModel>> FindAllFilms()
        {
            return await _dbContext.Films.ToListAsync();
        }

        public async Task<FilmModel> FindFilmById(int id)
        {
            return await _dbContext.Films.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilmModel> AddFilm(FilmModel film)
        {
            await _dbContext.Films.AddAsync(film);
            await _dbContext.SaveChangesAsync();
            return film;
        }

        public async Task<FilmModel> UpdateFilm(FilmModel film, int id)
        {
            FilmModel filmById = await FindFilmById(id);

            if(filmById == null)
            {
                throw new Exception($"O filme para o ID= {id} não foi encontrado no banco de dados");
            }
            filmById.Title = film.Title;
            filmById.Gender = film.Gender;
            filmById.Duration = film.Duration;
            filmById.Classification = film.Classification;

            _dbContext.Films.Update(filmById);
            await _dbContext.SaveChangesAsync();

            return filmById;
        }
        

        public async Task<bool> DeleteFilm(int id)
        {
            FilmModel filmById = await FindFilmById(id);

            if (filmById == null)
            {
                throw new Exception($"O filme para o ID= {id} não foi encontrado no banco de dados");
            }

            _dbContext.Films.Remove(filmById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
    }
}
