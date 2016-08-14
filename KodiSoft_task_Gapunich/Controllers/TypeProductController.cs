using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodiSoft_task_Gapunich.Controllers;

namespace KodiSoft_task_Gapunich.Controllers
{
    public class TypeProductController : Controller
    {
        ContextKodiSoft db = new ContextKodiSoft();
        // GET: TypeProduct
        public ActionResult Index()
        {
            var type = db.Typeproducts;
            return View(type.ToList());
        }

        [HttpGet]
        public ActionResult CreateTypeProduct()                     // создаем новый сервис
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTypeProduct(Typeproducts typeproduct)
        {

            db.Typeproducts.Add(typeproduct);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult EditTypeProduct(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Typeproducts typeproduct= db.Typeproducts.Find(id);

            if (typeproduct == null)
            {
                return HttpNotFound();
            }
            return View(typeproduct);
        }
        [HttpPost]
        public ActionResult EditTypeProduct(Typeproducts typeproduct)
        {
            db.Entry(typeproduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteTypeProduct(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Typeproducts typeproduct = db.Typeproducts.Find(id);
            if (typeproduct == null)
            {
                return HttpNotFound();
            }
            return View(typeproduct);
        }


        [HttpPost, ActionName("DeleteTypeProduct")]
        public ActionResult DeleteTypeProductConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Typeproducts b = db.Typeproducts.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Typeproducts.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetaliTypeProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Typeproducts typeproduct = db.Typeproducts.Find(id);
            if (typeproduct == null)
            {
                return HttpNotFound();
            }
            return View(typeproduct);
        }
    }
}