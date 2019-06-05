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
    public class ZayavkasController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: Zayavkas
        public ActionResult Index()
        {
            var zayavka = db.Zayavka.Include(z => z.Detali).Include(z => z.Fillial).Include(z => z.Oblast).Include(z => z.Users);
            return View(zayavka.ToList());
        }

        // GET: Zayavkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zayavka zayavka = db.Zayavka.Find(id);
            if (zayavka == null)
            {
                return HttpNotFound();
            }
            return View(zayavka);
        }

        // GET: Zayavkas/Create
        public ActionResult Create()
        {
            ViewBag.IdDetal = new SelectList(db.Detali, "Id", "NmDetal");
            ViewBag.IdFilial = new SelectList(db.Fillial, "Id", "NmFilial");
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast");
            ViewBag.IdUser = new SelectList(db.Users, "Id", "FName");
            return View();
        }

        // POST: Zayavkas/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUser,Data,IdOblast,IdFilial,IdDetal,Comment")] Zayavka zayavka)
        {
            zayavka.Data = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Zayavka.Add(zayavka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDetal = new SelectList(db.Detali, "Id", "NmDetal", zayavka.IdDetal);
            ViewBag.IdFilial = new SelectList(db.Fillial, "Id", "NmFilial", zayavka.IdFilial);
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", zayavka.IdOblast);
            ViewBag.IdUser = new SelectList(db.Users, "Id", "FName", zayavka.IdUser);
            return View(zayavka);
        }

        // GET: Zayavkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zayavka zayavka = db.Zayavka.Find(id);
            if (zayavka == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDetal = new SelectList(db.Detali, "Id", "NmDetal", zayavka.IdDetal);
            ViewBag.IdFilial = new SelectList(db.Fillial, "Id", "NmFilial", zayavka.IdFilial);
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", zayavka.IdOblast);
            ViewBag.IdUser = new SelectList(db.Users, "Id", "FName", zayavka.IdUser);
            return View(zayavka);
        }

        // POST: Zayavkas/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUser,Data,IdOblast,IdFilial,IdDetal,Comment")] Zayavka zayavka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zayavka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDetal = new SelectList(db.Detali, "Id", "NmDetal", zayavka.IdDetal);
            ViewBag.IdFilial = new SelectList(db.Fillial, "Id", "NmFilial", zayavka.IdFilial);
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", zayavka.IdOblast);
            ViewBag.IdUser = new SelectList(db.Users, "Id", "FName", zayavka.IdUser);
            return View(zayavka);
        }

        // GET: Zayavkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zayavka zayavka = db.Zayavka.Find(id);
            if (zayavka == null)
            {
                return HttpNotFound();
            }
            return View(zayavka);
        }

        // POST: Zayavkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zayavka zayavka = db.Zayavka.Find(id);
            db.Zayavka.Remove(zayavka);
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
