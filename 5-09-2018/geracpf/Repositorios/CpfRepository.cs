using geracpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geracpf.Repositorios
{
    public class CpfRepository
    {
        public static List<CpfModel> ListaDeCPF = new List<CpfModel> {
            new CpfModel {Cpf = "123.456.789-20" },
            new CpfModel {Cpf = "464.906.898-39" },
            new CpfModel {Cpf = "350.256.974-23" },
            new CpfModel {Cpf = "137.893.561-95" }
        };

        public static List<CpfModel> BuscarCPF()
        {
            return ListaDeCPF;
        }
    }
}