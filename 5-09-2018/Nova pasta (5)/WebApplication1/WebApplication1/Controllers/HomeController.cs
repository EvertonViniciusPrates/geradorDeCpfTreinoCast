using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.repositorios;

namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller
    {

        //[Route("api/predio")]
        //[HttpGet("api/predio")]
        //public IActionResult ObterPredio()
        //{
        //    //return NotFound();
        //    //return Unauthorized();
        //    return Ok("Prédio");
        //}
        private readonly IPessoaRepositorio reposiBase;

        public IActionResult Pessoas()
        {
            return reposiBase.BuscarTodos();
        }

        public IActionResult DetalharPessoa()
        {
            var pessoa = new PessoaViewModel("José", DateTime.Now, "Da Silva");
            return View(pessoa);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
