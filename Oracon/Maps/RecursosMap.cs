using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oracon.Models;

namespace Oracon.Maps
{
    public class RecursosMap : IEntityTypeConfiguration<Recursos>
    {
        public void Configure(EntityTypeBuilder<Recursos> builder)
        {
            builder.ToTable("Recursos");
            builder.HasKey(o => o.Id);
        }
    }
}
