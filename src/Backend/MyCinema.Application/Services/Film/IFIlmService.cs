using MyCinema.Communication.Requests;
using MyCinema.Communication.Response;

namespace MyCinema.Application.Services.Film
{
    public interface IFIlmService :IBaseServiceInterface<ResponseRegisteredFilmJson,RequestRegisterFilmJson>
    {
     
        public Task<List<ResponseRegisteredFilmJson>> GetAll();

        public Task<ResponseRegisteredFilmJson> GetById(int id);

        public Task<ResponseRegisteredFilmJson> Add(RequestRegisterFilmJson request);

        public Task<ResponseRegisteredFilmJson> Update(RequestRegisterFilmJson request, int id);

        public Task<bool> Delete(int id);
    }
}
