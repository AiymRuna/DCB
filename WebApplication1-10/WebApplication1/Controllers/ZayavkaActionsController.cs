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
    public class ZayavkaActionsController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: ZayavkaActions
        public ActionResult Index()
        {
            return View(db.ZayavkaAction.ToList());
        }

        // GET: ZayavkaActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaAction zayavkaAction = db.ZayavkaAction.Find(id);
            if (zayavkaAction == null)
            {
                return HttpNotFound();
            }
            return View(zayavkaAction);
        }

        // GET: ZayavkaActions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZayavkaActions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NmAction")] ZayavkaAction zayavkaAction)
        {
            if (ModelState.IsValid)
            {
                db.ZayavkaAction.Add(zayavkaAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zayavkaAction);
        }

        // GET: ZayavkaActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaAction zayavkaAction = db.ZayavkaAction.Find(id);
            if (zayavkaAction == null)
            {
                return HttpNotFound();
            }
            return View(zayavkaAction);
        }

        // POST: ZayavkaActions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NmAction")] ZayavkaAction zayavkaAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zayavkaAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zayavkaAction);
        }

        // GET: ZayavkaActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZayavkaAction zayavkaAction = db.ZayavkaAction.Find(id);
            if (zayavkaAction == null)
            {
                return HttpNotFound();
            }
            return View(zayavkaAction);
        }

        // POST: ZayavkaActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZayavkaAction zayavkaAction = db.ZayavkaAction.Find(id);
            db.ZayavkaAction.Remove(zayavkaAction);
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
