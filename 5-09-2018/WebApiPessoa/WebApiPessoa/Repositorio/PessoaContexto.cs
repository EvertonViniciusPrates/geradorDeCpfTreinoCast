using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiPessoa.Models;

namespace WebApiPessoa.Repositorio
{
    public static class PessoaContexto
    {
        private static List<Pessoa> _pessoas = new List<Pessoa>
        {
            new Pessoa(1,"444.222.098-09","FelipãoDev",DateTime.Now),
            new Pessoa(2,"444.222.999-19","VishDev",DateTime.Now),
            new Pessoa(3,"444.123.032-19","RonaldinhoDev",DateTime.Now),
            new Pessoa(4,"145.242.018-59","EitaDev",DateTime.Now)
        };

        public static void Add(Pessoa pessoa)
        {
            var codigo = 0;

            if (_pessoas != null && _pessoas.Any())
                codigo = _pessoas.LastOrDefault().Id;
            
            pessoa.Id = ++codigo;

            _pessoas.Add(pessoa);
        }

        public static void Remove (Pessoa pessoa)
        {
            _pessoas.Remove(pessoa);
        }

        public static List<Pessoa> ConsultarTodos()
        {
            return _pessoas;
        }

        public static Pessoa ConsultarPorId(Func<Pessoa,bool> expressao)
        {
            return _pessoas.FirstOrDefault(expressao);
        }

        public static bool Update(Predicate<Pessoa> expressao, Pessoa pessoa)
        {
            var index = _pessoas.FindIndex(expressao);

            if (index > 0)
            {
                _pessoas[index] = pessoa;
                return true;
            }
            return false;
        }

    }
}