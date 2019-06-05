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
    public class FillialsController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: Fillials
        public ActionResult Index()
        {
            var fillial = db.Fillial.Include(f => f.Oblast);
            return View(fillial.ToList());
        }

        // GET: Fillials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fillial fillial = db.Fillial.Find(id);
            if (fillial == null)
            {
                return HttpNotFound();
            }
            return View(fillial);
        }

        // GET: Fillials/Create
        public ActionResult Create()
        {
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast");
            return View();
        }

        // POST: Fillials/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdOblast,NmFilial")] Fillial fillial)
        {
            if (ModelState.IsValid)
            {
                db.Fillial.Add(fillial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", fillial.IdOblast);
            return View(fillial);
        }

        // GET: Fillials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fillial fillial = db.Fillial.Find(id);
            if (fillial == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", fillial.IdOblast);
            return View(fillial);
        }

        // POST: Fillials/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdOblast,NmFilial")] Fillial fillial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fillial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", fillial.IdOblast);
            return View(fillial);
        }

        // GET: Fillials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fillial fillial = db.Fillial.Find(id);
            if (fillial == null)
            {
                return HttpNotFound();
            }
            return View(fillial);
        }

        // POST: Fillials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fillial fillial = db.Fillial.Find(id);
            db.Fillial.Remove(fillial);
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
