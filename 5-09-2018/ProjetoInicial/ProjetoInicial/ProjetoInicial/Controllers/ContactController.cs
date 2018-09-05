using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjetoInicial.Models;

namespace ProjetoInicial.Controllers
{
    public class ContactController : Controller
    {
        public static List<ContactModel> Contacts { get; set; }

        public ContactController()
        {
            if (Contacts == null)
            {
                Contacts = new List<ContactModel>
                {
                    new ContactModel
                    {
                        Id = 1,
                        Type = "Phone",
                        Contact = "(00)00000-0000"
                    },
                    new ContactModel
                    {
                        Id = 2,
                        Type = "Phone",
                        Contact = "(11)11111-1111"
                    },
                    new ContactModel
                    {
                        Id = 3,
                        Type = "E-mail",
                        Contact = "email@gmail.com"
                    }
                };
            }
        }

        public ActionResult Index()
        {
            return View(Contacts);
        }

        public ActionResult New()
        {
            return View("New", new ContactModel());
        }

        public ActionResult Details(int id)
        {
            return View("Details", Contacts.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult Edit(int id)
        {
            return View("Edit", Contacts.FirstOrDefault(x => x.Id == id));
        }

        //[HttpPost]
        //public ActionResult Salvar(ContactModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model.Id > 0)
        //            Contacts[Contacts.IndexOf(model)] = model;
        //        else
        //            model.Id = Contacts.Count + 1;

        //        Contacts.Add(model);
        //    }

        //    return View("Index", Contacts);
        //}

        public ActionResult Delete(int id)
        {
            Contacts.RemoveAll(x => x.Id == id);

            return RedirectToAction("Index");
        }
    }
}