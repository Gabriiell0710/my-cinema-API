using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Application.Services.Room
{
    public interface IRoomService : IBaseServiceInterface<ResponseRegisteredRoomJson,RequestRegisterRoomJson>
    {
        
        public Task<List<ResponseRegisteredRoomJson>> GetAll();
        public Task<ResponseRegisteredRoomJson> GetById (int id);
        public Task<ResponseRegisteredRoomJson> Add(RequestRegisterRoomJson request);
        public Task<ResponseRegisteredRoomJson> Update(RequestRegisterRoomJson request, int id);
        public Task<bool> Delete(int id);

    }
}
