using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }



        public ActionResult ToReport()
        {
           
            return RedirectToAction("Index", "Report");
            //return View("~/RDLC_ReportTutorial.aspx");
        }
        public ActionResult ToReport1()
        {
            //int userID = (int)Session["userID"];
            return RedirectToAction("Index1", "Report");
            //return View("~/RDLC_ReportTutorial.aspx");
        }



    }
}
