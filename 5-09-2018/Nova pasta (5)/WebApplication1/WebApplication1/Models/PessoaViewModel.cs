using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PessoaViewModel
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Sobrenome { get; set; }

        public PessoaViewModel(string nome, DateTime dataDeNascimento, string sobrenome)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Sobrenome = sobrenome;
        }
    }
}
