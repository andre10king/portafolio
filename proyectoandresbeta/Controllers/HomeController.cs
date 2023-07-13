using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoandresbeta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Consultar()
        {
            return View();
        } 

       public ActionResult Consultar2()
        {
            return View();

        }

        public ActionResult Consultar3()
        {
            return View();

        }

    }
}
