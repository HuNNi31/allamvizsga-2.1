using System.Web.Mvc;

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

        }
        public ActionResult ToProfil()
        {

            return RedirectToAction("Profil", "Home");

        }

    }
}