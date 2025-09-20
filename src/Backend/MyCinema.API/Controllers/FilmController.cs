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

        [HttpPost]
        public async Task<ActionResult<ResponseRegisteredFilmJson>> Create([FromBody] RequestRegisterFilmJson request)
        {
            ResponseRegisteredFilmJson responseRegister = await _filmService.AddFilm(request);

            return Ok(responseRegister);
        }
    }
}
