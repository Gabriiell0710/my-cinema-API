using MyCinema.Communication.Enums;

namespace MyCinema.Domain.Models
{
    public class UserModel : ModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ProfileEnum Profile { get; set; }

    }
}
