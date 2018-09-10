using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minhaloja.Context;
using minhaloja.Models;

namespace minhaloja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly MinhaLojaContexto _minhaLojaContexto;

        public CategoriaController(MinhaLojaContexto minhaLojaContexto)
        {
            _minhaLojaContexto = minhaLojaContexto;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_minhaLojaContexto.Categorias.ToList());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            //cria novo código para o categoria
            categoria.Id = Guid.NewGuid();

            //adiciona o categoria no meu contexto == banco de dados
            _minhaLojaContexto.Categorias.Add(categoria);

            //commita o contexto
            _minhaLojaContexto.SaveChanges();

            return Ok(_minhaLojaContexto.Categorias.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            return Ok(_minhaLojaContexto.Categorias.Where(x => x.Id.Equals(id)));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var categoria = _minhaLojaContexto.Categorias.FirstOrDefault(x => x.Id.Equals(id));
            if (categoria != null)
            {
                _minhaLojaContexto.Categorias.Remove(categoria);
                _minhaLojaContexto.SaveChanges();
                return Ok("Fabricante deletado com sucesso!");
            }
            return Ok("Não foi possivel remover o fabricante de cnpj: " + id + " tente novamente mais tarde");
        }
    }
}