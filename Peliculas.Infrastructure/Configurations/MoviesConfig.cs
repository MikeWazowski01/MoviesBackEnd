using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Peliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infrastructure.Configurations
{
    public class MoviesConfig : IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.HasKey(x => x.idMovie);
            builder.HasOne(d => d.Director).WithMany(m => m.Movies).HasForeignKey(m => m.idDirector).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
