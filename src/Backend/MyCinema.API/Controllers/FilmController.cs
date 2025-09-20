using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCinema.Application.Services.Film;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFIlmService _filmService;

        public FilmController(IFIlmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseRegisteredFilmJson>>> GetAll()
        {
            List<ResponseRegisteredFilmJson> films = await _filmService.FindAllFilms();

            return Ok(films);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseRegisteredFilmJson>> FindById(int id)
        {
            ResponseRegisteredFilmJson film = await _filmService.FindFilmById(id);

            return Ok(film);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseRegisteredFilmJson>> Create([FromBody] RequestRegisterFilmJson request)
        {
            ResponseRegisteredFilmJson responseRegister = await _filmService.AddFilm(request);

            return Ok(responseRegister);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseRegisteredFilmJson>> Update([FromBody] RequestRegisterFilmJson request, int id)
        {
            ResponseRegisteredFilmJson film = await _filmService.UpdateFilm(request,id);

            return Ok(film);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseRegisteredFilmJson>> Delete (int id)
        {
            await _filmService.DeleteFilm(id);

            return Ok(true);
        }
    }
}
