using MyCinema.Domain.Enums;

namespace MyCinema.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ProfileEnum Profile { get; set; }
        public int? SessionID { get; set; } 


        public virtual SessionModel Session { get; set; }

    }
}
