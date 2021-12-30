using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class CatalogoProdutoMap : IEntityTypeConfiguration<CatalogoProduto>
    {
        public void Configure(EntityTypeBuilder<CatalogoProduto> builder)
        {
            builder.ToTable("CatalogoProduto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasColumnType("int").IsRequired();
            
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasColumnType("varchar").IsRequired();
            builder.Property(x => x.PrecoVenda).HasColumnName("precoVenda").HasColumnType("int").IsRequired();
            builder.Property(x => x.CategoriaId).HasColumnName("categoriaId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Categoria).WithMany().HasForeignKey(x => x.CategoriaId).IsRequired();

        }
    }
}