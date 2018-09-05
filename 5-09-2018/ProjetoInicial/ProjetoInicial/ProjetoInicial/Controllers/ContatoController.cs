using ProjetoInicial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoInicial.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato

        public static List<ContatoModel> Contatos { get; set; }

        public ContatoController()
        {
            if(Contatos == null)
            {
                Contatos = new List<ContatoModel>
                {
                    new ContatoModel{
                        Id = 1,
                        Tipo = "Telefone",
                        Contato = "(00)00000-0000"
                    },
                    new ContatoModel{
                        Id = 2,
                        Tipo = "Celular",
                        Contato = "(00)00000-0000"
                    }
                };
            }
        }

        public ActionResult Index()
        {
            ViewBag.message = "Seus contatos";
            return View(Contatos);
        }

        public ActionResult Detalhar(int id)
        {
            return View(Contatos.FirstOrDefault(x => x.Id == id));
        }
        public ActionResult Editar(int id)
        {
            return View(Contatos.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        //[Route("SalvarContato")]
        public ActionResult Salvar(ContatoModel model)
        { 
            var index = Contatos.FindLastIndex(x => x.Id == model.Id);

            if (index.Equals(index++))
            {
                if (ModelState.IsValid)
                {
                    if (index >= 0)
                    {
                        Contatos[index] = model;
                    }
                    else
                    {
                        model.Id = Contatos.Count + 1;
                        Contatos.Add(model);
                    }
                }
            }

            
            return View("Index", Contatos);
        }



    }
}