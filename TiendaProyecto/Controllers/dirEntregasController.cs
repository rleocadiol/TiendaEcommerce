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
    public class dirEntregasController : Controller
    {
        private conteTienda db = new conteTienda();

        // GET: dirEntregas
        public ActionResult Index()
        {
            var dirEntrega = db.dirEntrega.Include(d => d.cliente);
            return View(dirEntrega.ToList());
        }

        // GET: dirEntregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dirEntrega dirEntrega = db.dirEntrega.Find(id);
            if (dirEntrega == null)
            {
                return HttpNotFound();
            }
            return View(dirEntrega);
        }

        // GET: dirEntregas/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.cliente, "Id_cliente", "nombre");
            return View();
        }

        // POST: dirEntregas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_dirEntrega,calle,colonia,estado,tel,id_cliente")] dirEntrega dirEntrega)
        {
            if (ModelState.IsValid)
            {
                db.dirEntrega.Add(dirEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.cliente, "Id_cliente", "nombre", dirEntrega.id_cliente);
            return View(dirEntrega);
        }

        // GET: dirEntregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dirEntrega dirEntrega = db.dirEntrega.Find(id);
            if (dirEntrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "Id_cliente", "nombre", dirEntrega.id_cliente);
            return View(dirEntrega);
        }

        // POST: dirEntregas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_dirEntrega,calle,colonia,estado,tel,id_cliente")] dirEntrega dirEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dirEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "Id_cliente", "nombre", dirEntrega.id_cliente);
            return View(dirEntrega);
        }

        // GET: dirEntregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dirEntrega dirEntrega = db.dirEntrega.Find(id);
            if (dirEntrega == null)
            {
                return HttpNotFound();
            }
            return View(dirEntrega);
        }

        // POST: dirEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dirEntrega dirEntrega = db.dirEntrega.Find(id);
            db.dirEntrega.Remove(dirEntrega);
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
