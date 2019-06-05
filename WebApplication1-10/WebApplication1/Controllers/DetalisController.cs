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
    public class DetalisController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: Detalis
        public ActionResult Index()
        {
            return View(db.Detali.ToList());
        }

        // GET: Detalis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detali detali = db.Detali.Find(id);
            if (detali == null)
            {
                return HttpNotFound();
            }
            return View(detali);
        }

        // GET: Detalis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Detalis/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NmDetal")] Detali detali)
        {
            if (ModelState.IsValid)
            {
                db.Detali.Add(detali);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detali);
        }

        // GET: Detalis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detali detali = db.Detali.Find(id);
            if (detali == null)
            {
                return HttpNotFound();
            }
            return View(detali);
        }

        // POST: Detalis/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NmDetal")] Detali detali)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detali).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detali);
        }

        // GET: Detalis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detali detali = db.Detali.Find(id);
            if (detali == null)
            {
                return HttpNotFound();
            }
            return View(detali);
        }

        // POST: Detalis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detali detali = db.Detali.Find(id);
            db.Detali.Remove(detali);
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
