using System.Collections.Generic;

namespace WebApplication1.repositorios
{
    public interface ICarroRepositorio{
        List<CarroViewModel> GetAll();
    }
}
