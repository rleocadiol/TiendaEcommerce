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
    [Authorize]
    public class productosController : Controller
    {
        private conteTienda db = new conteTienda();

        // GET: productos
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: productos/Create
        public ActionResult Create()
        {
            ViewBag.id_subcategoria = new SelectList(db.subcategoria, "Id_subcategoria", "nombre");
            return View();
        }

        // POST: productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_producto,nombre,precio,descripcion,imagen,existencia,stock,id_subcategoria")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                int id = producto.Id_producto;
                var prod = db.producto.Find(id);
                DateTime hoy = DateTime.Now;
                prod.ult_actualizacion = hoy;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_subcategoria = new SelectList(db.subcategoria, "Id_subcategoria", "nombre", producto.id_subcategoria);
            return View(producto);
        }

        // GET: productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_subcategoria = new SelectList(db.subcategoria, "Id_subcategoria", "nombre", producto.id_subcategoria);
            return View(producto);
        }

        // POST: productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_producto,nombre,precio,descripcion,ult_actualizacion,imagen,existencia,stock,id_subcategoria")] producto producto)
        {
            if (ModelState.IsValid)
            {
                int id = producto.Id_producto;
                var prod = db.producto.Find(id);
                var precio_ant = prod.precio;
                var precio_act = producto.precio;

                //db.Entry(producto).State = EntityState.Modified;

                prod.nombre = producto.nombre;
                prod.descripcion = producto.descripcion;
                prod.precio = producto.precio;
                prod.imagen = producto.imagen;
                prod.existencia = producto.existencia;
                prod.stock = producto.stock;
                prod.id_subcategoria = producto.id_subcategoria;

                if (precio_act != precio_ant)
                {
                    DateTime hoy = DateTime.Now;
                    prod.ult_actualizacion = hoy;
                }

                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            ViewBag.id_subcategoria = new SelectList(db.subcategoria, "Id_subcategoria", "nombre", producto.id_subcategoria);
            return View(producto);
        }

        // GET: productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.producto.Find(id);
            db.producto.Remove(producto);
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
