using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCinema.Application.Services.Room;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseRegisteredRoomJson>>> FindAll()
        {
            List<ResponseRegisteredRoomJson> roomList = await _roomService.FindAllRooms();

            return Ok(roomList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseRegisteredRoomJson>> FindById(int id)
        {
            ResponseRegisteredRoomJson room = await _roomService.FindRoomById(id);

            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseRegisteredRoomJson>> Create (RequestRegisterRoomJson request)
        {
            ResponseRegisteredRoomJson room = await _roomService.AddRoom(request);

            return Ok(room);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseRegisteredRoomJson>> Update (RequestRegisterRoomJson request, int id)
        {
            ResponseRegisteredRoomJson room = await _roomService.UpdateRoom(request, id);

            return Ok(room);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseRegisteredRoomJson>> Delete (int id)
        {
            await _roomService.DeleteRoom(id);

            return Ok(true);
        }
    }
}
