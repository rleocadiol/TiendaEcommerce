using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaProyecto.Models;

namespace TiendaProyecto.Controllers
{
    public class paqueteriaController : Controller
    {
        private conteTienda db = new conteTienda();

        // GET: paqueteria
        public ActionResult Index()
        {
            return View(db.paqueteria.ToList());
        }

        // GET: paqueteria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paqueteria paqueteria = db.paqueteria.Find(id);
            if (paqueteria == null)
            {
                return HttpNotFound();
            }
            return View(paqueteria);
        }

        // GET: paqueteria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: paqueteria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_paqueteria,nombre,rfc,tel,web,direccion,contacto,tel_contacto")] paqueteria paqueteria)
        {
            if (ModelState.IsValid)
            {
                db.paqueteria.Add(paqueteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paqueteria);
        }

        // GET: paqueteria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paqueteria paqueteria = db.paqueteria.Find(id);
            if (paqueteria == null)
            {
                return HttpNotFound();
            }
            return View(paqueteria);
        }

        // POST: paqueteria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_paqueteria,nombre,rfc,tel,web,direccion,contacto,tel_contacto")] paqueteria paqueteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paqueteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paqueteria);
        }

        // GET: paqueteria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paqueteria paqueteria = db.paqueteria.Find(id);
            if (paqueteria == null)
            {
                return HttpNotFound();
            }
            return View(paqueteria);
        }

        // POST: paqueteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paqueteria paqueteria = db.paqueteria.Find(id);
            db.paqueteria.Remove(paqueteria);
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
