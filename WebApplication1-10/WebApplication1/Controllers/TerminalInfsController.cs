using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class TerminalInfsController : Controller
    {
        private DCBEntities db = new DCBEntities();

        // GET: TerminalInfs
        public ActionResult Index()
        {
            var terminalInf = db.TerminalInf.Include(t => t.Fillial).Include(t => t.Oblast).Include(t => t.OrgType).Include(t => t.TerminalStatus);
            return View(terminalInf.ToList());
        }

        // GET: Report TerminalInfs
        public ActionResult Reports(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/TerminalInfRep.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "TerminalInfDataSet";
            reportDataSource.Value = db.TerminalInf.ToList();
            localReport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtention;
            if(reportType == "Excel")   {    fileNameExtention = "xlsx";    }
            else if (reportType == "Word")  { fileNameExtention = "docx"; }
            else if (reportType == "PDF") { fileNameExtention = "pdf"; }

            string[] streams;   
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtention, out streams, out warnings);
            Response.AddHeader("Content-Disposition", "attachment; filename = terminals_report." + fileNameExtention);
            return File(renderedByte, fileNameExtention);
        }

        // GET: TerminalInfs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalInf terminalInf = db.TerminalInf.Find(id);
            if (terminalInf == null)
            {
                return HttpNotFound();
            }
            return View(terminalInf);
        }

        // GET: TerminalInfs/Create
        public ActionResult Create()
        {
            ViewBag.IdFilial = new SelectList(db.Fillial, "Id", "NmFilial");
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast");
            ViewBag.IdTypeOrg = new SelectList(db.OrgType, "Id", "NmOrgType");
            ViewBag.IdStatus = new SelectList(db.TerminalStatus, "Id", "NmTerStatus");
            return View();
        }

        // POST: TerminalInfs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdOblast,IdFilial,NomerTerminal,Shtrihkod,IdStatus,Data,IdTypeOrg,NameOrg,Address,SummArenda,Comment")] TerminalInf terminalInf)
        {
            if (ModelState.IsValid)
            {
                db.TerminalInf.Add(terminalInf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFilial = new SelectList(db.Fillial, "Id", "NmFilial", terminalInf.IdFilial);
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", terminalInf.IdOblast);
            ViewBag.IdTypeOrg = new SelectList(db.OrgType, "Id", "NmOrgType", terminalInf.IdTypeOrg);
            ViewBag.IdStatus = new SelectList(db.TerminalStatus, "Id", "NmTerStatus", terminalInf.IdStatus);
            return View(terminalInf);
        }

        // GET: TerminalInfs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalInf terminalInf = db.TerminalInf.Find(id);
            if (terminalInf == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFilial = new SelectList(db.Fillial, "Id", "NmFilial", terminalInf.IdFilial);
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", terminalInf.IdOblast);
            ViewBag.IdTypeOrg = new SelectList(db.OrgType, "Id", "NmOrgType", terminalInf.IdTypeOrg);
            ViewBag.IdStatus = new SelectList(db.TerminalStatus, "Id", "NmTerStatus", terminalInf.IdStatus);
            return View(terminalInf);
        }

        // POST: TerminalInfs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdOblast,IdFilial,NomerTerminal,Shtrihkod,IdStatus,Data,IdTypeOrg,NameOrg,Address,SummArenda,Comment")] TerminalInf terminalInf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminalInf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFilial = new SelectList(db.Fillial, "Id", "NmFilial", terminalInf.IdFilial);
            ViewBag.IdOblast = new SelectList(db.Oblast, "Id", "NmOblast", terminalInf.IdOblast);
            ViewBag.IdTypeOrg = new SelectList(db.OrgType, "Id", "NmOrgType", terminalInf.IdTypeOrg);
            ViewBag.IdStatus = new SelectList(db.TerminalStatus, "Id", "NmTerStatus", terminalInf.IdStatus);
            return View(terminalInf);
        }

        // GET: TerminalInfs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerminalInf terminalInf = db.TerminalInf.Find(id);
            if (terminalInf == null)
            {
                return HttpNotFound();
            }
            return View(terminalInf);
        }

        // POST: TerminalInfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TerminalInf terminalInf = db.TerminalInf.Find(id);
            db.TerminalInf.Remove(terminalInf);
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
