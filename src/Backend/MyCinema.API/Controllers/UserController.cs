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
            List<ResponseRegisteredUserJson> users = await _userService.FindAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseRegisteredUserJson>> GetById(int id)
        {
            var user = await _userService.FindUserById(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseRegisteredUserJson>> Create(RequestRegisterUserJson request)
        {
            var user = await _userService.AddUser(request);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseRegisteredUserJson>> Update (RequestRegisterUserJson request, int id)
        {
            var user = await _userService.UpdateUser(request, id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseRegisteredUserJson>> Delete (int id)
        {
            await _userService.DeleteUser(id);
            return Ok("Deletado");
        }
    }
}
