using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.repositorios
{
    public interface IPessoaRepositorio
    {
        List<PessoaViewModel> GetAll();
    }
    
}