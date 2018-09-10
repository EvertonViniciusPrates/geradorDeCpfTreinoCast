using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minhaloja.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public IList<Produto> Produtos { get; set; }


    }
}
