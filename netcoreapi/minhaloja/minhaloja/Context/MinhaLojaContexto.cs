using Microsoft.EntityFrameworkCore;
using minhaloja.Maps;
using minhaloja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minhaloja.Context
{
    public class MinhaLojaContexto : DbContext
    {
        public MinhaLojaContexto(DbContextOptions<MinhaLojaContexto> options)
            : base(options)
        {
            
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new FabricanteMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
