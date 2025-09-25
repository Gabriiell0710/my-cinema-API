using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCinema.Application.Services.Session;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseRegisteredSessionJson>>> GetAll()
        {
           List<ResponseRegisteredSessionJson> session = await _sessionService.FindAllSessions();

           return Ok(session);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseRegisteredSessionJson>> GetById (int id)
        {
            ResponseRegisteredSessionJson session = await _sessionService.FindSessionById(id);

            return Ok(session);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseRegisteredSessionJson>> Create (RequestRegisterSessionJson request)
        {
            ResponseRegisteredSessionJson session = await _sessionService.AddSession(request);
            return Ok(session);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseRegisteredSessionJson>> Update (RequestRegisterSessionJson request, int id)
        {
            ResponseRegisteredSessionJson session = await _sessionService.UpdateSession(request, id);
            return Ok(session);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseRegisteredSessionJson>> Delete (int id)
        {
            await _sessionService.DeleteSession(id);
            return Ok("Deletado");
        }
    }
}
