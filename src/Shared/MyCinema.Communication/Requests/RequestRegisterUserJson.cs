using MyCinema.Communication.Enums;

namespace MyCinema.Communication.Requests
{
    public class RequestRegisterUserJson
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ProfileEnum Profile { get; set; }
    }
}
