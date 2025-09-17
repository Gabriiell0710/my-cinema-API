using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCinema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Infrastructure.DataAcess.Map
{
    public class FilmMap : IEntityTypeConfiguration<FilmModel>
    {
        public void Configure(EntityTypeBuilder<FilmModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x=> x.Classification).IsRequired().HasMaxLength(100);
        }
    }
}
