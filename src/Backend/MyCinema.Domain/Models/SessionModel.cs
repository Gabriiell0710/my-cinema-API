using MyCinema.Communication.Enums;

namespace MyCinema.Domain.Models
{
    public class SessionModel : ModelBase
    {
        public DateTime DateAndTime { get; set; }
        public int FilmId { get; set; }
        public int RoomId { get; set; }
        public SessionStatusEnum Status { get; set; }

        public virtual FilmModel Film { get; set; }
        public virtual RoomModel Room { get; set; }
    }
}
