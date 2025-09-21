using AutoMapper;
using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using MyCinema.Domain.Models;

namespace MyCinema.Application.AutoMapper
{
    public class AutoMapping: Profile
    {
        public  AutoMapping() 
        { 
            CreateMap<RequestRegisterFilmJson, FilmModel>();
            CreateMap<FilmModel, ResponseRegisteredFilmJson>();
            CreateMap<RequestRegisterRoomJson, RoomModel>();
            CreateMap<RoomModel, ResponseRegisteredRoomJson>();
        }
    }
}
