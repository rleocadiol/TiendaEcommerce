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
    public class subcategoriasController : Controller
    {
        private conteTienda db = new conteTienda();

        // GET: subcategorias
        public ActionResult Index()
        {
            var subcategoria = db.subcategoria.Include(s => s.categoria);
            return View(subcategoria.ToList());
        }

        // GET: subcategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategoria.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        // GET: subcategorias/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.categoria, "Id_categoria", "nombre");
            return View();
        }

        // POST: subcategorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_subcategoria,nombre,descripcion,id_categoria")] subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.subcategoria.Add(subcategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.categoria, "Id_categoria", "nombre", subcategoria.id_categoria);
            return View(subcategoria);
        }

        // GET: subcategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategoria.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "Id_categoria", "nombre", subcategoria.id_categoria);
            return View(subcategoria);
        }

        // POST: subcategorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_subcategoria,nombre,descripcion,id_categoria")] subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "Id_categoria", "nombre", subcategoria.id_categoria);
            return View(subcategoria);
        }

        // GET: subcategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategoria.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        // POST: subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subcategoria subcategoria = db.subcategoria.Find(id);
            db.subcategoria.Remove(subcategoria);
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
