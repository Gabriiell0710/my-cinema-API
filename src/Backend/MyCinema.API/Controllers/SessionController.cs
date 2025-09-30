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
           List<ResponseRegisteredSessionJson> session = await _sessionService.GetAll();

           return Ok(session);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseRegisteredSessionJson>> GetById (int id)
        {
            ResponseRegisteredSessionJson session = await _sessionService.GetById(id);

            return Ok(session);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseRegisteredSessionJson>> Add (RequestRegisterSessionJson request)
        {
            ResponseRegisteredSessionJson session = await _sessionService.Add(request);
            return Ok(session);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseRegisteredSessionJson>> Update (RequestRegisterSessionJson request, int id)
        {
            var session = await _sessionService.Update(request, id);
            return Ok(session);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseRegisteredSessionJson>> Delete (int id)
        {
            await _sessionService.Delete(id);
            return Ok("Deletado");
        }
    }
}
