using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Sistema de cadastro de produtos utilizando ASP.Net MVC 4 e SQL Server.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aprendendo a programar com Cleyton Ferrari.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sua area de contato.";

            return View();
        }
    }
}
