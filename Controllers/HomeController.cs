using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS4200_Team8_Scrum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Centric Consulting.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to contact us and learn more about Centric.";

            return View();
        }
        public ActionResult CoreValues()
        {

            return View();
        }
    }
}