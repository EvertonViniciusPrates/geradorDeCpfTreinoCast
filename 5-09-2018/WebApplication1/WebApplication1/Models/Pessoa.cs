using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
        }

        public Pessoa(string cpf, string nome, DateTime dataDeNascimento)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
        }

        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set }
    }
}