namespace MyCinema.Communication.Requests
{
    public class RequestRegisterSessionJson
    {
        public DateTime DateAndTime { get; set; }
        public int FilmId { get; set; }
        public int RoomId { get; set; }
    }
}
