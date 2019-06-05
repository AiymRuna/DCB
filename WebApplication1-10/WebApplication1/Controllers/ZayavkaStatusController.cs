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
    public class ZayavkaStatusController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: ZayavkaStatus
        public ActionResult Index()
        {
            return View(db.ZayavkaStatus.ToList());
        }

        // GET: ZayavkaStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaStatus zayavkaStatus = db.ZayavkaStatus.Find(id);
            if (zayavkaStatus == null)
            {
                return HttpNotFound();
            }
            return View(zayavkaStatus);
        }

        // GET: ZayavkaStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZayavkaStatus/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NmZStatus")] ZayavkaStatus zayavkaStatus)
        {
            if (ModelState.IsValid)
            {
                db.ZayavkaStatus.Add(zayavkaStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zayavkaStatus);
        }

        // GET: ZayavkaStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaStatus zayavkaStatus = db.ZayavkaStatus.Find(id);
            if (zayavkaStatus == null)
            {
                return HttpNotFound();
            }
            return View(zayavkaStatus);
        }

        // POST: ZayavkaStatus/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NmZStatus")] ZayavkaStatus zayavkaStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zayavkaStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zayavkaStatus);
        }

        // GET: ZayavkaStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaStatus zayavkaStatus = db.ZayavkaStatus.Find(id);
            if (zayavkaStatus == null)
            {
                return HttpNotFound();
            }
            return View(zayavkaStatus);
        }

        // POST: ZayavkaStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZayavkaStatus zayavkaStatus = db.ZayavkaStatus.Find(id);
            db.ZayavkaStatus.Remove(zayavkaStatus);
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
