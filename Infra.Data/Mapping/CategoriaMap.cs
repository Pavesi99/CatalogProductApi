using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasColumnType("int").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar").IsRequired();
        }
    }
}