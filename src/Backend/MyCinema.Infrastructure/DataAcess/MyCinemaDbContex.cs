using Microsoft.EntityFrameworkCore;
using MyCinema.Communication.Requests;
using MyCinema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Infrastructure.DataAcess
{
    public class MyCinemaDbContex : DbContext 
    {
        public MyCinemaDbContex(DbContextOptions<MyCinemaDbContex> options) : base(options) { }

        public DbSet<FilmModel> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
