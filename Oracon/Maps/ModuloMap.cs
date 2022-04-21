using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oracon.Models;

namespace Oracon.Maps
{
    public class ModuloMap : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.ToTable("Modulo");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Clases).
                WithOne().
                HasForeignKey(o => o.IdModulo);
        }
    }
}
