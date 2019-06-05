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
    public class ZayavkaOtvetsController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: ZayavkaOtvets
        public ActionResult Index()
        {
            var zayavkaOtvet = db.ZayavkaOtvet.Include(z => z.Users).Include(z => z.Zayavka).Include(z => z.ZayavkaAction).Include(z => z.ZayavkaStatus);
            return View(zayavkaOtvet.ToList());
        }

        // GET: ZayavkaOtvets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaOtvet zayavkaOtvet = db.ZayavkaOtvet.Find(id);
            if (zayavkaOtvet == null)
            {
                return HttpNotFound();
            }
            return View(zayavkaOtvet);
        }

        // GET: ZayavkaOtvets/Create
        public ActionResult Create()
        {
            ViewBag.IdUser = new SelectList(db.Users, "Id", "FName");
            ViewBag.IdZayavka = new SelectList(db.Zayavka, "Id", "Comment");
            ViewBag.IdAction = new SelectList(db.ZayavkaAction, "Id", "NmAction");
            ViewBag.IdStatus = new SelectList(db.ZayavkaStatus, "Id", "NmZStatus");
            return View();
        }

        // POST: ZayavkaOtvets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUser,Data,IdZayavka,IdStatus,IdAction,Cost")] ZayavkaOtvet zayavkaOtvet)
        {
            zayavkaOtvet.Data = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ZayavkaOtvet.Add(zayavkaOtvet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUser = new SelectList(db.Users, "Id", "FName", zayavkaOtvet.IdUser);
            ViewBag.IdZayavka = new SelectList(db.Zayavka, "Id", "Comment", zayavkaOtvet.IdZayavka);
            ViewBag.IdAction = new SelectList(db.ZayavkaAction, "Id", "NmAction", zayavkaOtvet.IdAction);
            ViewBag.IdStatus = new SelectList(db.ZayavkaStatus, "Id", "NmZStatus", zayavkaOtvet.IdStatus);
            return View(zayavkaOtvet);
        }

        // GET: ZayavkaOtvets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaOtvet zayavkaOtvet = db.ZayavkaOtvet.Find(id);
            if (zayavkaOtvet == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUser = new SelectList(db.Users, "Id", "FName", zayavkaOtvet.IdUser);
            ViewBag.IdZayavka = new SelectList(db.Zayavka, "Id", "Comment", zayavkaOtvet.IdZayavka);
            ViewBag.IdAction = new SelectList(db.ZayavkaAction, "Id", "NmAction", zayavkaOtvet.IdAction);
            ViewBag.IdStatus = new SelectList(db.ZayavkaStatus, "Id", "NmZStatus", zayavkaOtvet.IdStatus);
            return View(zayavkaOtvet);
        }

        // POST: ZayavkaOtvets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUser,Data,IdZayavka,IdStatus,IdAction,Cost")] ZayavkaOtvet zayavkaOtvet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zayavkaOtvet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUser = new SelectList(db.Users, "Id", "FName", zayavkaOtvet.IdUser);
            ViewBag.IdZayavka = new SelectList(db.Zayavka, "Id", "Comment", zayavkaOtvet.IdZayavka);
            ViewBag.IdAction = new SelectList(db.ZayavkaAction, "Id", "NmAction", zayavkaOtvet.IdAction);
            ViewBag.IdStatus = new SelectList(db.ZayavkaStatus, "Id", "NmZStatus", zayavkaOtvet.IdStatus);
            return View(zayavkaOtvet);
        }

        // GET: ZayavkaOtvets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaOtvet zayavkaOtvet = db.ZayavkaOtvet.Find(id);
            if (zayavkaOtvet == null)
            {
                return HttpNotFound();
            }
            return View(zayavkaOtvet);
        }

        // POST: ZayavkaOtvets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZayavkaOtvet zayavkaOtvet = db.ZayavkaOtvet.Find(id);
            db.ZayavkaOtvet.Remove(zayavkaOtvet);
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
