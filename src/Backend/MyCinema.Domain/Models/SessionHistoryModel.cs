using MyCinema.Communication.Enums;

namespace MyCinema.Domain.Models
{
    public class SessionHistoryModel : ModelBase
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public SessionStatusEnum Status { get; set; }

        public virtual UserModel User { get; set; }
        public virtual SessionModel Session { get; set; }

    }
}
