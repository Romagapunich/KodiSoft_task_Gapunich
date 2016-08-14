using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodiSoft_task_Gapunich.Controllers;

namespace KodiSoft_task_Gapunich.Controllers
{
    public class ContactController : Controller
    {
        ContextKodiSoft db = new ContextKodiSoft();
        // GET: TypeProduct
        public ActionResult Index()
        {
            var type = db.Contacts;
            return View(type.ToList());
        }

        [HttpGet]
        public ActionResult CreateContact()                     // создаем новый сервис
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Contacts contacts)
        {

            db.Contacts.Add(contacts);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult EditContact(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Contacts contact = db.Contacts.Find(id);

            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public ActionResult EditContact(Contacts contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteContact(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Contacts contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }


        [HttpPost, ActionName("DeleteContact")]
        public ActionResult DeleteContactConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Contacts b = db.Contacts.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Contacts.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetaliContact(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Contacts contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
    }
}