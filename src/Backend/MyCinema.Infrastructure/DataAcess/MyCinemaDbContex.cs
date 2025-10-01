using Microsoft.EntityFrameworkCore;
using MyCinema.Domain.Models;
using MyCinema.Infrastructure.DataAcess.Map;

namespace MyCinema.Infrastructure.DataAcess
{
    public class MyCinemaDbContex : DbContext 
    {
        public MyCinemaDbContex(DbContextOptions<MyCinemaDbContex> options) : base(options) { }

        public DbSet<FilmModel> Films { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<SessionModel> Sessions { get; set; }
        public DbSet<UserModel> Users { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmMap());
            modelBuilder.ApplyConfiguration(new RoomMap());
            modelBuilder.ApplyConfiguration(new SessionMap());
            modelBuilder.ApplyConfiguration(new  UserMap());
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
