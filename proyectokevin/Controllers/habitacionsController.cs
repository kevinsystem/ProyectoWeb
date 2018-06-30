using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyectokevin.Models;

namespace proyectokevin.Controllers
{
    public class habitacionsController : Controller
    {
        private hotel_vangohEntities db = new hotel_vangohEntities();

        // GET: habitacions
        [Authorize]
        public ActionResult Index()//METODO PRINCIPAL QUE SIRVE PARA LISTAR REGISTROS TODAS LAS HABITACIONES
        {
            var habitacion = db.habitacion.Include(h => h.tipo_habitacion);
            return View(habitacion.ToList());
        }

        // GET: habitacions/Details/5
        public ActionResult Details(int? id)//METODO PARA ACCEDER AL DETALLE DEL REGISTRO(HABTIACION)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            habitacion habitacion = db.habitacion.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            return View(habitacion);
        }

        // GET: habitacions/Create
        public ActionResult Create()//METODO PARA INGRESAR AL FORMULARIO DE NUEVO REGISTRO
        {
            ViewBag.tih_id = new SelectList(db.tipo_habitacion, "id", "tih_codigo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,hab_codigo,hab_descripcion,hab_fotop,hab_precio,tih_id")] habitacion habitacion)
        {//CUANDO SE CONFIRMA EL NUEVO REGISTRO
            if (ModelState.IsValid)
            {
                db.habitacion.Add(habitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tih_id = new SelectList(db.tipo_habitacion, "id", "tih_codigo", habitacion.tih_id);
            return View(habitacion);
        }

        // GET: habitacions/Edit/5
        public ActionResult Edit(int? id)//METODO QUE BUSCA UN ID Y MUESTRA EN EL FORMULARIO EDITAR
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            habitacion habitacion = db.habitacion.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.tih_id = new SelectList(db.tipo_habitacion, "id", "tih_codigo", habitacion.tih_id);
            return View(habitacion);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,hab_codigo,hab_descripcion,hab_fotop,hab_precio,tih_id")] habitacion habitacion)
        {//CUANDO YA SE CONFIRMÓ LA EDICION DEL REGISTRO 
            if (ModelState.IsValid)
            {
                db.Entry(habitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tih_id = new SelectList(db.tipo_habitacion, "id", "tih_codigo", habitacion.tih_id);
            return View(habitacion);
        }
        
        public ActionResult Delete(int? id)//METODO QUE BUSCA UN REGISTRO Y MUESTRA EN LA VISTA BORRAR
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            habitacion habitacion = db.habitacion.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            return View(habitacion);
        }

        // POST: habitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)//METODO Q ES LLAMADO CUANDO SE CONFIRMA LA ELIMINACION
        {
            habitacion habitacion = db.habitacion.Find(id);
            db.habitacion.Remove(habitacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
