using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCLogin.Controllers
{   
    
    public class HomeController : Controller
    {
       
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Tanar()
        {
            return View();
        }
        public ActionResult Profil()
        {
            return View();
        }


        public ActionResult ToTanar()
        {

            return RedirectToAction("Tanar", "Home");
            //return View("~/RDLC_ReportTutorial.aspx");
        }
        public ActionResult ToProfil()
        {

            return RedirectToAction("Profil", "Home");
            //return View("~/RDLC_ReportTutorial.aspx");
        }

    }
}