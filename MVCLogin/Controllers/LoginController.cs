using MVCLogin.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Autherize(MVCLogin.Models.User userModel)
        {
            using (minosegbiztositasEntities db = new minosegbiztositasEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {

                    userModel.LoginErrorMessage = "Wrong username or password.";

                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.UserName;

                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {

            Session.Abandon();
            Session.Clear();
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
            Session["userID"] = null;
            return RedirectToAction("Index", "Login");
        }

    }
}