using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication1.repositorios;

namespace WebApplication1.Controllers
{
    public class Pessoa : ApiController
    {
        public HttpResponseMessage Get()
        {
            var pessoas = PessoaContext.ConsultarTodos();
            return Request.CreateResponse(HttpStatusCode.OK, pessoas);
        }
    }
}