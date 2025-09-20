using MyCinema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Domain.RepositoriesInterfaces.Room
{
    public interface IRoomWriteOnlyRepository
    {
        Task<RoomModel> AddRoom(RoomModel romm);
        Task<RoomModel> UpdateRoom(RoomModel room, int id);
        Task<bool> DeleteRoom(int id);
    }
}
