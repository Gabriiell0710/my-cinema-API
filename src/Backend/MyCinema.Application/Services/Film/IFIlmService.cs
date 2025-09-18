using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Application.Services.Film
{
    public interface IFIlmService
    {
        public Task<ResponseRegisteredFilmJson> AddFilm(RequestRegisterFilmJson request);
    }
}
