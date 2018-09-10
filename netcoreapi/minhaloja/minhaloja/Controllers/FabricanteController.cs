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
    public class FabricanteController : Controller
    {
        private readonly MinhaLojaContexto _minhaLojaContexto;

        public FabricanteController(MinhaLojaContexto minhaLojaContexto)
        {
            _minhaLojaContexto = minhaLojaContexto;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_minhaLojaContexto.Fabricantes.ToList());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Fabricante fabricante)
        {
            //cria novo código para o fabricante
            fabricante.Id = Guid.NewGuid();

            //adiciona o fabricante no meu contexto == banco de dados
            _minhaLojaContexto.Fabricantes.Add(fabricante);

            //commita o contexto
            _minhaLojaContexto.SaveChanges();

            return Ok(_minhaLojaContexto.Fabricantes.ToList());
        }
        [HttpGet("{cnpj}")]
        public IActionResult BuscarPorCnpj(string cnpj)
        {
            return Ok(_minhaLojaContexto.Fabricantes.Where(x => x.Cnpj.Equals(cnpj)));
        }

        [HttpDelete("{cnpj}")]
        public IActionResult Delete(string cnpj)
        {
            var fabricante = _minhaLojaContexto.Fabricantes.FirstOrDefault(x => x.Cnpj.Equals(cnpj));
            if (fabricante != null)
            {
                _minhaLojaContexto.Fabricantes.Remove(fabricante);
                _minhaLojaContexto.SaveChanges();
                return Ok("Fabricante deletado com sucesso!");
            }
            return Ok("Não foi possivel remover o fabricante de cnpj: " + cnpj + " tente novamente mais tarde");
        }
    }
}