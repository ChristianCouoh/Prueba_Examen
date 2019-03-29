using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestion_Asistencias.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Desarrollado Por Christian Couoh como Examen..";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Christian.couoh@gmail.com";

            return View();
        }
    }
}