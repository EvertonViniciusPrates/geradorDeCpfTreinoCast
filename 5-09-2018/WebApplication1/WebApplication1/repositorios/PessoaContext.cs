using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.repositorios
{
    public class PessoaContext
    {
        private static List<Pessoa> _pessoas => new List<Pessoa>
        {
            new Pessoa("123.456.789-12","NOME UM",DateTime.Now),
            new Pessoa("321.654.987-39","NOME DOIS",DateTime.Now),
            new Pessoa("121.654.231-56","NOME TRES",DateTime.Now),
            new Pessoa("231.654.956-98","NOME QUATRO",DateTime.Now)

        };

        public static void Add(Pessoa pessoa)
        {
            _pessoas.Add(pessoa);
        }
        public static void Remove(Pessoa pessoa)
        {
            _pessoas.Remove(pessoa);
        }
        public static List<Pessoa> ConsultarTodos()
        {
            return _pessoas;
        }
        public static Pessoa ConsultarPorId(Func<Pessoa, bool> expressao)
        {
            return _pessoas.FirstOrDefault(x => x.Id.Equals(expressao));
        }

    }
}