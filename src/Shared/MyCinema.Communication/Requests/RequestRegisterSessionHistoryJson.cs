using MyCinema.Communication.Enums;

namespace MyCinema.Communication.Requests
{
    public class RequestRegisterSessionHistoryJson
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public SessionStatusEnum Status { get; set; }
    }
}
