﻿using System;
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
    public class OrgTypesController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: OrgTypes
        public ActionResult Index()
        {
            return View(db.OrgType.ToList());
        }

        // GET: OrgTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgType orgType = db.OrgType.Find(id);
            if (orgType == null)
            {
                return HttpNotFound();
            }
            return View(orgType);
        }

        // GET: OrgTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrgTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NmOrgType,Description")] OrgType orgType)
        {
            if (ModelState.IsValid)
            {
                db.OrgType.Add(orgType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orgType);
        }

        // GET: OrgTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgType orgType = db.OrgType.Find(id);
            if (orgType == null)
            {
                return HttpNotFound();
            }
            return View(orgType);
        }

        // POST: OrgTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NmOrgType,Description")] OrgType orgType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orgType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orgType);
        }

        // GET: OrgTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgType orgType = db.OrgType.Find(id);
            if (orgType == null)
            {
                return HttpNotFound();
            }
            return View(orgType);
        }

        // POST: OrgTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrgType orgType = db.OrgType.Find(id);
            db.OrgType.Remove(orgType);
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
