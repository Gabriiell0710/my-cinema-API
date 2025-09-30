using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCinema.Application.Services.User;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseRegisteredUserJson>>> GetAll()
        {
            List<ResponseRegisteredUserJson> users = await _userService.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseRegisteredUserJson>> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseRegisteredUserJson>> Add(RequestRegisterUserJson request)
        {
            var user = await _userService.Add(request);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseRegisteredUserJson>> Update (RequestRegisterUserJson request, int id)
        {
            var user = await _userService.Update(request, id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseRegisteredUserJson>> Delete (int id)
        {
            await _userService.Delete(id);
            return Ok("Deletado");
        }
    }
}
