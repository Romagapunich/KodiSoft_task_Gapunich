using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodiSoft_task_Gapunich.Controllers;

namespace KodiSoft_task_Gapunich.Controllers
{
    public class HomeController : Controller
    {
        private ContextKodiSoft db = new ContextKodiSoft();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(int? id)
        {
            id = 1;
            if (id == null)
            {
                return HttpNotFound();
            }
            Descriptions description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);

           
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var contacts = db.Contacts;
            return View(contacts.ToList());
        }
        public ActionResult ProductList()
        {
            var groupe = db.Products;
            return View(groupe.ToList());
        }
        public ActionResult Pizza()
        {
            var groupe = db.Products;
            return View(groupe.ToList());
        }
        public ActionResult Sushi()
        {
            var groupe = db.Products;
            return View(groupe.ToList());
        }
        public ActionResult Desert()
        {
            var groupe = db.Products;
            return View(groupe.ToList());
        }
    }
}