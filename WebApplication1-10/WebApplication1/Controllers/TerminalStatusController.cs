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
    public class TerminalStatusController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: TerminalStatus
        public ActionResult Index()
        {
            return View(db.TerminalStatus.ToList());
        }

        // GET: TerminalStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalStatus terminalStatus = db.TerminalStatus.Find(id);
            if (terminalStatus == null)
            {
                return HttpNotFound();
            }
            return View(terminalStatus);
        }

        // GET: TerminalStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TerminalStatus/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NmTerStatus")] TerminalStatus terminalStatus)
        {
            if (ModelState.IsValid)
            {
                db.TerminalStatus.Add(terminalStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terminalStatus);
        }

        // GET: TerminalStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalStatus terminalStatus = db.TerminalStatus.Find(id);
            if (terminalStatus == null)
            {
                return HttpNotFound();
            }
            return View(terminalStatus);
        }

        // POST: TerminalStatus/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NmTerStatus")] TerminalStatus terminalStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminalStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terminalStatus);
        }

        // GET: TerminalStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalStatus terminalStatus = db.TerminalStatus.Find(id);
            if (terminalStatus == null)
            {
                return HttpNotFound();
            }
            return View(terminalStatus);
        }

        // POST: TerminalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TerminalStatus terminalStatus = db.TerminalStatus.Find(id);
            db.TerminalStatus.Remove(terminalStatus);
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
