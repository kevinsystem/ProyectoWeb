using proyectokevin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace proyectokevin.Controllers
{
    public class HomeController : Controller
    {
        private hotel_vangohEntities db = new hotel_vangohEntities();
        public ActionResult Index()
        {
            var habitacion = db.habitacion.Include(h => h.tipo_habitacion);
            return View(habitacion.ToList());
        }

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
    }
}