using MyCinema.Communication.Enums;

namespace MyCinema.Domain.Models
{
    public class UserHistoryModel :ModelBase
    {
        public int UserId { get; set; }
        public string  FilmName { get; set; }
        public string RoomName { get; set; }
        public DateTime DateTime { get; set; }
        public SessionStatusEnum StatusName { get; set; } 

        public virtual UserModel User { get; set; }
        public virtual FilmModel Film { get; set; }
        public virtual RoomModel Room { get; set; }
        public virtual SessionModel Date { get; set; }
        public virtual SessionModel Status { get; set; }

    }
}
