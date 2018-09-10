using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minhaloja.Models
{
    public class Produto
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Nome { get; set; }

        public DateTime DataDeFabricacao { get; set; }


        //chave estrangeira 
        public Guid CategoriaId { get; set; }
        //
        public Categoria Categoria { get; set; }

        //chave estrangeira 
        public Guid FabricanteId { get; set; }
        //
        public Fabricante Fabricante { get; set; }
    }
}
