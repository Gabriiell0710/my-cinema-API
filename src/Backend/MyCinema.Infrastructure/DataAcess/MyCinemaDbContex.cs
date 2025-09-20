using Microsoft.EntityFrameworkCore;
using MyCinema.Domain.Models;

namespace MyCinema.Infrastructure.DataAcess
{
    public class MyCinemaDbContex : DbContext 
    {
        public MyCinemaDbContex(DbContextOptions<MyCinemaDbContex> options) : base(options) { }

        public DbSet<FilmModel> Films { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
