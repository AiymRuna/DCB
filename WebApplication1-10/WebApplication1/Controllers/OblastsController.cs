using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OblastsController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: Oblasts
        public ActionResult Index()
        {
            return View(db.Oblast.ToList());
        }

        // GET: Oblasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oblast oblast = db.Oblast.Find(id);
            if (oblast == null)
            {
                return HttpNotFound();
            }
            return View(oblast);
        }

        // GET: Oblasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oblasts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NmOblast")] Oblast oblast)
        {
            if (ModelState.IsValid)
            {
                db.Oblast.Add(oblast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oblast);
        }

        // GET: Oblasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oblast oblast = db.Oblast.Find(id);
            if (oblast == null)
            {
                return HttpNotFound();
            }
            return View(oblast);
        }

        // POST: Oblasts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NmOblast")] Oblast oblast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oblast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oblast);
        }

        // GET: Oblasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oblast oblast = db.Oblast.Find(id);
            if (oblast == null)
            {
                return HttpNotFound();
            }
            return View(oblast);
        }

        // POST: Oblasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oblast oblast = db.Oblast.Find(id);
            db.Oblast.Remove(oblast);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
