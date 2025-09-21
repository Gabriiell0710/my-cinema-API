using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Application.Services.Room
{
    public interface IRoomService
    {
        public Task<ResponseRegisteredRoomJson> AddRoom(RequestRegisterRoomJson request);
        public Task<List<ResponseRegisteredRoomJson>> FindAllRooms();
        public Task<ResponseRegisteredRoomJson> FindRoomById (int id);
        public Task<ResponseRegisteredRoomJson> UpdateRoom(RequestRegisterRoomJson request, int id);
        public Task<bool> DeleteRoom(int id);

    }
}
