using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCinema.Domain.Models;

namespace MyCinema.Infrastructure.DataAcess.Map
{
    public class SessionMap : IEntityTypeConfiguration<SessionModel>
    {
        public void Configure(EntityTypeBuilder<SessionModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DateAndTime).IsRequired();
            builder.Property(x => x.FilmId).IsRequired();
            builder.Property(x => x.RoomId).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.Film);
            builder.HasOne(x => x.Room);

        }
    }
}
