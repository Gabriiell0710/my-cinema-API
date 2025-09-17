namespace MyCinema.Domain.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Gender { get; set; }
        public int Duration { get; set; }
        public string? Classification { get; set; }

    }
}
