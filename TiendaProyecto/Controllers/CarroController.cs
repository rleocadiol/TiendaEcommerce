using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaProyecto.Models;

namespace TiendaProyecto.Controllers
{
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar(int id)
        {
            prodCarro carro = new prodCarro();
            if (Session["cart"]==null)
            {
                List<item> cart = new List<item>();
                producto p = carro.find(id);
                string name = p.nombre;
                cart.Add(new item { Producto = carro.find(id), Cantidad = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<item> cart = (List<item>) Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Cantidad++;
                }
                else
                {
                    producto p = carro.find(id);
                    string nam = p.nombre;
                    cart.Add(new item { Producto = carro.find(id), Cantidad = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<item> cart = (List<item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Producto.Id_producto.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult Quitar(int id)
        {
            List<item> cart = (List<item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
    }
}