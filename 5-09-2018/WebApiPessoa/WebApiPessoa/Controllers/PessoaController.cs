using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPessoa.Models;
using WebApiPessoa.Repositorio;

namespace WebApiPessoa.Controllers
{
    //api/Pessoa/
    [RoutePrefix("api/pessoa")]
    [FiltrarRequisicao]
    public class PessoaController : ApiController
    {
        [Route("consultarpornome/{nome}")]
        [HttpGet]
        public HttpResponseMessage ConsultarPorNome(string nome)
        {
            var pessoa = PessoaContexto.ConsultarPorId(x => x.Nome.Equals(nome));
            return Request.CreateResponse(HttpStatusCode.OK, pessoa);
        }

        public HttpResponseMessage Get()
        {
            var pessoas = PessoaContexto.ConsultarTodos();

            return Request.CreateResponse(HttpStatusCode.OK, pessoas);
        }

        public HttpResponseMessage Get (int id)
        {
            var pessoa = PessoaContexto.ConsultarPorId(x => x.Id.Equals(id));

            return Request.CreateResponse(HttpStatusCode.OK, pessoa);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Pessoa pessoa)
        {
            PessoaContexto.Add(pessoa);

            return Request.CreateResponse(HttpStatusCode.Created, PessoaContexto.ConsultarTodos());
        }

        [HttpPut]
        public HttpResponseMessage Put(int codigo, [FromBody]Pessoa pessoa)
        {
            var updtValido = PessoaContexto.Update(x => x.Id == codigo, pessoa);
            var status = updtValido ? HttpStatusCode.Accepted : HttpStatusCode.NoContent;

            return Request.CreateResponse(status, PessoaContexto.ConsultarTodos());
        }

        public HttpResponseMessage Delete(int codigo) {
            var pessoa = PessoaContexto.ConsultarPorId(x => x.Id == codigo);
            if(pessoa != null)
            {
                PessoaContexto.Remove(pessoa);
                return Request.CreateResponse(HttpStatusCode.OK, PessoaContexto.ConsultarTodos());
            }
            return Request.CreateResponse(HttpStatusCode.OK, pessoa);
        }
    }
}
