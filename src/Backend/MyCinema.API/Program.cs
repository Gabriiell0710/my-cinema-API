
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyCinema.Application.AutoMapper;
using MyCinema.Application.Services.Film;
using MyCinema.Application.Services.Room;
using MyCinema.Application.Services.Session;
using MyCinema.Domain.RepositoriesInterfaces.Film;
using MyCinema.Domain.RepositoriesInterfaces.Room;
using MyCinema.Domain.RepositoriesInterfaces.Session;
using MyCinema.Infrastructure.DataAcess;
using MyCinema.Infrastructure.Repositories.Film;
using MyCinema.Infrastructure.Repositories.Room;
using MyCinema.Infrastructure.Repositories.Session;

namespace MyCinema.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<MyCinemaDbContex>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                );

            builder.Services.AddScoped<IFilmReadOnlyRepository, FilmRepository>();
            builder.Services.AddScoped<IFilmWriteOnlyRepository, FilmRepository>();
            builder.Services.AddScoped<IRoomReadOnlyRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomWriteOnlyRepository, RoomRepository>();
            builder.Services.AddScoped<ISessionReadOnlyRepository, SessionRepository>();
            builder.Services.AddScoped<ISessionWriteOnlyRepository, SessionRepository>();
            builder.Services.AddScoped<IFIlmService, FilmService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddAutoMapper(typeof(AutoMapping));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
