using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Peliculas.Domain.Entities;

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
