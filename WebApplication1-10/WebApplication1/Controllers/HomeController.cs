using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private DCBEntities db = new DCBEntities();


        public ActionResult Index()
        {
            return View();
        }

        // GET: /about
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Maps()
        {
            return View();
        }

        public ActionResult getTerminalsLocationApi()
        {
            var terminals = db.GetTerminalLocationWithAddress.ToList();
            string output = JsonConvert.SerializeObject(terminals);

            return Json(output, JsonRequestBehavior.AllowGet);
        }
    }
}