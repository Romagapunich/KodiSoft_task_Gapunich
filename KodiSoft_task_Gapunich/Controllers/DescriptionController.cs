using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodiSoft_task_Gapunich.Controllers;

namespace KodiSoft_task_Gapunich.Controllers
{
    public class DescriptionController : Controller
    {
        ContextKodiSoft db = new ContextKodiSoft();
        // GET: Description
        [HttpGet]
        public ActionResult EditDescription(int? id)
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
        [HttpPost]
        public ActionResult EditDescription(Descriptions description)
        {
            db.Entry(description).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditDescription");
        }
    }
}
