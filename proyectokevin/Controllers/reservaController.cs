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
    public class reservaController : Controller
    {
        private hotel_vangohEntities db = new hotel_vangohEntities();
        [Authorize]
        // GET: reserva
        public ActionResult Index()
        {
            var reserva = db.reserva.Include(r => r.cliente).Include(r => r.habitacion).Include(r => r.usuario);
            return View(reserva.ToList());
        }

        // GET: reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }
        [Authorize]
        // GET: reserva/Create
        public ActionResult Create()
        {
            ViewBag.cli_id = new SelectList(db.cliente, "id", "cli_codigo");
            ViewBag.hab_id = new SelectList(db.habitacion, "id", "hab_codigo");
            ViewBag.usu_id = new SelectList(db.usuario, "id", "usu_usuario");
            return View();
        }

        // POST: reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,hab_id,cli_id,usu_id,res_fecha_registro,res_fecha_reserva,res_estado,res_monto")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cli_id = new SelectList(db.cliente, "id", "cli_codigo", reserva.cli_id);
            ViewBag.hab_id = new SelectList(db.habitacion, "id", "hab_codigo", reserva.hab_id);
            ViewBag.usu_id = new SelectList(db.usuario, "id", "usu_usuario", reserva.usu_id);
            return View(reserva);
        }

        // GET: reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.cli_id = new SelectList(db.cliente, "id", "cli_codigo", reserva.cli_id);
            ViewBag.hab_id = new SelectList(db.habitacion, "id", "hab_codigo", reserva.hab_id);
            ViewBag.usu_id = new SelectList(db.usuario, "id", "usu_usuario", reserva.usu_id);
            return View(reserva);
        }

        // POST: reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,hab_id,cli_id,usu_id,res_fecha_registro,res_fecha_reserva,res_estado,res_monto")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cli_id = new SelectList(db.cliente, "id", "cli_codigo", reserva.cli_id);
            ViewBag.hab_id = new SelectList(db.habitacion, "id", "hab_codigo", reserva.hab_id);
            ViewBag.usu_id = new SelectList(db.usuario, "id", "usu_usuario", reserva.usu_id);
            return View(reserva);
        }

        // GET: reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reserva reserva = db.reserva.Find(id);
            db.reserva.Remove(reserva);
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
