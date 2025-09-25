namespace MyCinema.Domain.Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public int FilmId { get; set; }
        public int RoomId { get; set; }


        public virtual FilmModel Film { get; set; }
        public virtual RoomModel Room { get; set; }
    }
}
