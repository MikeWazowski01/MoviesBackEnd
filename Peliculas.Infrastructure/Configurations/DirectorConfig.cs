using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peliculas.Domain.Entities;

namespace Peliculas.Infrastructure.Configurations
{
    public class DirectorConfig: IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(d => d.idDirector);
        }
    }
}
