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
    public class tipo_clienteController : Controller
    {
        private hotel_vangohEntities db = new hotel_vangohEntities();

        // GET: tipo_cliente
        public ActionResult Index()
        {
            return View(db.tipo_cliente.ToList());
        }

        // GET: tipo_cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cliente tipo_cliente = db.tipo_cliente.Find(id);
            if (tipo_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cliente);
        }

        // GET: tipo_cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tic_codigo,tic_descripcion")] tipo_cliente tipo_cliente)
        {
            if (ModelState.IsValid)
            {
                db.tipo_cliente.Add(tipo_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_cliente);
        }

        // GET: tipo_cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cliente tipo_cliente = db.tipo_cliente.Find(id);
            if (tipo_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cliente);
        }

        // POST: tipo_cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tic_codigo,tic_descripcion")] tipo_cliente tipo_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_cliente);
        }

        // GET: tipo_cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cliente tipo_cliente = db.tipo_cliente.Find(id);
            if (tipo_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cliente);
        }

        // POST: tipo_cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_cliente tipo_cliente = db.tipo_cliente.Find(id);
            db.tipo_cliente.Remove(tipo_cliente);
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
