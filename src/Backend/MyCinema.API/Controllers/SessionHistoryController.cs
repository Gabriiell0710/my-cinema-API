using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCinema.Application.Services.SessionHistory;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionHistoryController : ControllerBase
    {
        private readonly ISessionHistoryService _sessionHistoryService;

        public SessionHistoryController(ISessionHistoryService sessionHistoryService)
        {
            _sessionHistoryService = sessionHistoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseRegisteredSessionHistoryJson>>> GetAll()
        {
            List<ResponseRegisteredSessionHistoryJson> sessionHistoryList = await _sessionHistoryService.GetAll();
            return Ok(sessionHistoryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseRegisteredSessionHistoryJson>> GetById(int id)
        {
            var sessionHistory = await _sessionHistoryService.GetById(id);
            return Ok(sessionHistory);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseRegisteredSessionHistoryJson>> Add (RequestRegisterSessionHistoryJson request)
        {
            var sessionHistory = await _sessionHistoryService.Add(request);
            return Ok(sessionHistory);
        }
 

    }
}
