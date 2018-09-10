using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minhaloja.Context;
using minhaloja.Models;

namespace minhaloja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly MinhaLojaContexto _minhaLojaContexto;

        public ProdutoController(MinhaLojaContexto minhaLojaContexto)
        {
            _minhaLojaContexto = minhaLojaContexto;
        }
        [HttpGet("{id}/categoria", Name = "GetCategoriaDoProduto")]
        public IActionResult GetCategoriaDoProduto(Guid id)
        {
            //select * from produto inner join categoria on produto.cd_categoria = categoria.id
            //         where produto.id = {id}
            var produto = _minhaLojaContexto.Produtos.Include(x => x.Categoria).FirstOrDefault(x => x.Id == id);
            if (produto == null) return NoContent();

            var categoriaDoProduto = produto.Categoria;

            return Ok(categoriaDoProduto);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_minhaLojaContexto.Produtos.ToList());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            //cria novo código para o Produto
            produto.Id = Guid.NewGuid();

            //adiciona o produto no meu contexto == banco de dados
            _minhaLojaContexto.Produtos.Add(produto);

            //commita o contexto
            _minhaLojaContexto.SaveChanges();

            return Ok(_minhaLojaContexto.Produtos.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            return Ok(_minhaLojaContexto.Produtos.Where(x => x.Id.Equals(id)));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var produto = _minhaLojaContexto.Produtos.FirstOrDefault(x => x.Id.Equals(id));
            if (produto != null)
            {
                _minhaLojaContexto.Produtos.Remove(produto);
                _minhaLojaContexto.SaveChanges();
                return Ok("Fabricante deletado com sucesso!");
            }
            return Ok("Não foi possivel remover o fabricante de cnpj: " + id + " tente novamente mais tarde");
        }
    }
}