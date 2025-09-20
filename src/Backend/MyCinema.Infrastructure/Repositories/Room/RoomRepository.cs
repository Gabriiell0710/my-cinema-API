using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyCinema.Domain.Models;
using MyCinema.Domain.RepositoriesInterfaces.Room;
using MyCinema.Infrastructure.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Infrastructure.Repositories.Room
{
    public class RoomRepository : IRoomReadOnlyRepository, IRoomWriteOnlyRepository
    {
        private readonly MyCinemaDbContex _dBContext;

        public RoomRepository(MyCinemaDbContex dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<RoomModel>> FindAllRooms()
        {
            return await _dBContext.Rooms.ToListAsync();
        }

        public async Task<RoomModel> FindRoomById(int id)
        {
            return await _dBContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<RoomModel> AddRoom(RoomModel room)
        {
            await _dBContext.Rooms.AddAsync(room);
            await _dBContext.SaveChangesAsync();
            return room;
        }

        public async Task<RoomModel> UpdateRoom(RoomModel room, int id)
        {
            RoomModel roomById = await FindRoomById(id);
            if( roomById == null)
            {
                throw new Exception($"A sala com o ID {id} não foi encontrada no banco de dados");
            }
            roomById.Name = room.Name;
            roomById.Capacity = room.Capacity;

            _dBContext.Rooms.Update(roomById);
            await _dBContext.SaveChangesAsync();

            return roomById;

        }

        public async Task<bool> DeleteRoom(int id)
        {
            RoomModel roomById = await FindRoomById(id);

            if (roomById == null)
            {
                throw new Exception($"A sala com o ID {id} não foi encontrada no banco de dados");
            }

             _dBContext.Rooms.Remove(roomById);
            await _dBContext.SaveChangesAsync();

            return true;
        }

    }
}
