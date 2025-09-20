using MyCinema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Domain.RepositoriesInterfaces.Room
{
    public interface IRoomReadOnlyRepository
    {
        Task<List<RoomModel>> FindAllRooms();
        Task<RoomModel> FindRoomById(int id);
    }
}
