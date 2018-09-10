using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhaloja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minhaloja.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_produto");
            builder.Property(x => x.Descricao).HasColumnName("dc_produto");
            builder.Property(x => x.Nome).HasColumnName("nm_produto");
            builder.Property(x => x.DataDeFabricacao).HasColumnName("dt_fabricacao");

            builder.Property(x => x.CategoriaId).HasColumnName("cd_categoria");
            builder.HasOne(x => x.Categoria).WithMany().HasForeignKey(x => x.CategoriaId).IsRequired();

            builder.Property(x => x.FabricanteId).HasColumnName("cd_fabricante");
            builder.HasOne(x => x.Fabricante).WithMany().HasForeignKey(x => x.FabricanteId).IsRequired();
        }
    }
}
