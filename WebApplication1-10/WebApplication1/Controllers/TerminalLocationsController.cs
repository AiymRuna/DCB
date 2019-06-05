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
    public class TerminalLocationsController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: TerminalLocations
        public ActionResult Index()
        {
            var terminalLocation = db.TerminalLocation.Include(t => t.TerminalInf);
            return View(terminalLocation.ToList());
        }

        // GET: TerminalLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalLocation terminalLocation = db.TerminalLocation.Find(id);
            if (terminalLocation == null)
            {
                return HttpNotFound();
            }
            return View(terminalLocation);
        }

        // GET: TerminalLocations/Create
        public ActionResult Create()
        {
            ViewBag.IdTerminal = new SelectList(db.TerminalInf, "Id", "NomerTerminal");
            return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTerminal,Longth,Width")] TerminalLocation terminalLocation)
        {
            if (ModelState.IsValid)
            {
                db.TerminalLocation.Add(terminalLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTerminal = new SelectList(db.TerminalInf, "Id", "NomerTerminal", terminalLocation.IdTerminal);
            return View(terminalLocation);
        }

        // GET: TerminalLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalLocation terminalLocation = db.TerminalLocation.Find(id);
            if (terminalLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTerminal = new SelectList(db.TerminalInf, "Id", "NomerTerminal", terminalLocation.IdTerminal);
            return View(terminalLocation);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdTerminal,Longth,Width")] TerminalLocation terminalLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminalLocation).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTerminal = new SelectList(db.TerminalInf, "Id", "NomerTerminal", terminalLocation.IdTerminal);
            return View(terminalLocation);
        }

        // GET: TerminalLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalLocation terminalLocation = db.TerminalLocation.Find(id);
            if (terminalLocation == null)
            {
                return HttpNotFound();
            }
            return View(terminalLocation);
        }

        // POST: TerminalLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TerminalLocation terminalLocation = db.TerminalLocation.Find(id);
            db.TerminalLocation.Remove(terminalLocation);
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
