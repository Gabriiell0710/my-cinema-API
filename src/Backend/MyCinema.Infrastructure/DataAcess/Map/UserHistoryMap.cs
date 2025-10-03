using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCinema.Domain.Models;

namespace MyCinema.Infrastructure.DataAcess.Map
{
    public class UserHistoryMap : IEntityTypeConfiguration<UserHistoryModel>
    {
        public void Configure(EntityTypeBuilder<UserHistoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.FilmName).IsRequired();
            builder.Property(x => x.RoomName).IsRequired();
            builder.Property(x => x.DateTime).IsRequired();
            builder.Property(x => x.StatusName).IsRequired();

            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Film);
            builder.HasOne(x => x.Room);
            builder.HasOne(x => x.Date);
            builder.HasOne(x => x.Status);

        }
    }
}
