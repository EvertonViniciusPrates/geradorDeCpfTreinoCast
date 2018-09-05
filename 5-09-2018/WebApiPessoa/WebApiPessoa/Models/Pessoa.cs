using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPessoa.Models
{
    public class Pessoa
    {
        public Pessoa() { }

        public Pessoa(int id, string cpf, string nome, DateTime dataDeNascimento)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}