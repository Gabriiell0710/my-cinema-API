namespace MyCinema.Domain.Models
{
    public class FilmModel : ModelBase
    {
        public string? Title { get; set; }
        public string? Gender { get; set; }
        public int Duration { get; set; }
        public string? Classification { get; set; }

    }
}
