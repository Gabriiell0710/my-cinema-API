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
            CreateMap<RequestRegisterSessionJson, SessionModel>();
            CreateMap<SessionModel, ResponseRegisteredSessionJson>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateAndTime.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.DateAndTime.Hour.ToString("hh:mm")))
                .ForMember(dest => dest.Film, opt => opt.MapFrom(src => src.Film.Title))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room.Name));
            CreateMap<RequestRegisterUserJson, UserModel>();
            CreateMap<UserModel,ResponseRegisteredUserJson>();
            CreateMap<RequestRegisterUserHistoryJson, UserHistoryModel>();
            CreateMap<UserHistoryModel, ResponseRegisteredUserHistoryJson>()
                .ForMember(dest => dest.FilmTitle, opt => opt.MapFrom(src => src.Film.Title))
                .ForMember(dest => dest.SessionDateTime, opt => opt.MapFrom(src => src.Date.DateAndTime.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatusName.ToString()));
           
        }
    }
}
