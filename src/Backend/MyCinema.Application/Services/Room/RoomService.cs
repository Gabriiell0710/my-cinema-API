using AutoMapper;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Application.Services.Room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomReadOnlyRepository _roomReadOnlyRepository;
        private readonly IRoomWriteOnlyRepository _roomWriteOnlyRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomReadOnlyRepository roomReadOnlyRepository, IRoomWriteOnlyRepository roomWriteOnlyRepository, IMapper mapper)
        {
            _roomReadOnlyRepository = roomReadOnlyRepository;
            _roomWriteOnlyRepository = roomWriteOnlyRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseRegisteredRoomJson>> FindAllRooms()
        {
            List<RoomModel> roomListModel = await _roomReadOnlyRepository.FindAllRooms();

            var rooms = _mapper.Map<List<ResponseRegisteredRoomJson>>(roomListModel);

            return rooms;
        }

        public async Task<ResponseRegisteredRoomJson> FindRoomById(int id)
        {
            RoomModel roomModel = await _roomReadOnlyRepository.FindRoomById(id);

            var room = _mapper.Map<ResponseRegisteredRoomJson>(roomModel);

            return room;
        }
        public async Task<ResponseRegisteredRoomJson> AddRoom(RequestRegisterRoomJson request)
        {
            var room = _mapper.Map<RoomModel>(request);

            await _roomWriteOnlyRepository.AddRoom(room);

            return new ResponseRegisteredRoomJson
            {
                Name = request.Name
            };
        }

        public async Task<ResponseRegisteredRoomJson> UpdateRoom(RequestRegisterRoomJson request, int id)
        {
            var requestModel = _mapper.Map<RoomModel>(request);
            RoomModel roomModel = await _roomWriteOnlyRepository.UpdateRoom(requestModel, id);

            var roomUpdated = _mapper.Map<ResponseRegisteredRoomJson>(roomModel);

            return roomUpdated;

        }

        public async Task<bool> DeleteRoom(int id)
        {
            await _roomWriteOnlyRepository.DeleteRoom(id);

            return true;
        }

        
    }
}
