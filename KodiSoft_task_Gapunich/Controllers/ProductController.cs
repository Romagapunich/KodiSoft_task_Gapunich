using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodiSoft_task_Gapunich.Controllers;

namespace KodiSoft_task_Gapunich.Controllers
{
    public class ProductController : Controller
    {
        ContextKodiSoft db = new ContextKodiSoft();
        // GET: Product
        public ActionResult Index()
        {
            var type = db.Products;
            return View(type.ToList());
        }

 [HttpGet]
        public ActionResult CreateProduct()                     // создаем новый сервис
        {
            var product = db.Typeproducts.Select(c => new
            {
                TypeproductID = c.Id,
                NameTypeProduct = c.Name
            }).ToList();
            ViewBag.TypeServices = new SelectList(product, "TypeproductID", "NameTypeProduct");

            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Products product)
        {
            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Products producteProduct = db.Products.Find(id);

            if (producteProduct == null)
            {
                return HttpNotFound();
            }
            var producte = db.Typeproducts.Select(c => new
            {
                TypeproductID = c.Id,
                NameTypeProduct = c.Name
            }).ToList();
            ViewBag.TypeServices = new SelectList(producte, "TypeproductID", "NameTypeProduct");
            return View(producteProduct);
        }
        [HttpPost]
        public ActionResult EditProduct(Products product)
        {

            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteProduct(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Products product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult DeleteProductConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Products product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetaliProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Products product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}