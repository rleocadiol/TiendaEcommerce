using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaProyecto.Models;

namespace TiendaProyecto.Controllers
{
    public class catalogoController : Controller
    {
        private contextTienda db = new contextTienda();
        // GET: catalogo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscaProd(string nomBuscar)
        {
            ViewBag.SearchKey = nomBuscar;
            using (db)
            {
                var query = from st in db.producto
                            where st.nombre.Contains(nomBuscar)
                            select st;
                var listProd = query.ToList();
                ViewBag.Listado = listProd;
            }
            return View();
        }
        public ActionResult prodCategoria(int idCat)
        {
            List<producto> mercancia = null;
            var query = from p in db.producto
                        where p.id_subcategoria == idCat
                        select p;
            //idCat corresponde al ID de la subcategoria
            //categoria1 se debe cambiar por el nombre de las categorias
            //El IF se debe repetir para cada categoría creada
            if (idCat == 1)
            {
                mercancia = query.ToList();
                ViewBag.Catego = "Cuchillos"; 
            }
            if (idCat == 2)
            {
                mercancia = query.ToList();
                ViewBag.Catego = "Cucharas";
            }
            if (idCat == 1002)
            {
                mercancia = query.ToList();
                ViewBag.Catego = "Tenedores";
            }
            if (idCat == 1003)
            {
                mercancia = query.ToList();
                ViewBag.Catego = "Platos";
            }
            ViewBag.productos = mercancia;
            return View();
        }
    }
}