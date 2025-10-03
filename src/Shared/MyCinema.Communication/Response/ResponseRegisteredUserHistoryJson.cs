using MyCinema.Communication.Enums;

namespace MyCinema.Communication.Response
{
    public class ResponseRegisteredUserHistoryJson
    {
        public string FilmTitle { get; set; }
        public string SessionDateTime { get; set; }
        public string Room {  get; set; }
        public string Status { get; set; }
    }
}
