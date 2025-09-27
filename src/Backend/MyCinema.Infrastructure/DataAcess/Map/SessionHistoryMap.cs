using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCinema.Domain.Models;

namespace MyCinema.Infrastructure.DataAcess.Map
{
    public class SessionHistoryMap : IEntityTypeConfiguration<SessionHistoryModel>
    {
        public void Configure(EntityTypeBuilder<SessionHistoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.SessionId).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Session);
        }
    }
}
