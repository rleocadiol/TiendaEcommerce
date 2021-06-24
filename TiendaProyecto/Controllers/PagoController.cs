using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TiendaProyecto.Models;

namespace TiendaProyecto.Controllers
{
    [Authorize]
    public class PagoController : Controller
    {
        private contextTienda db = new contextTienda();
        private string NumConfPago;

        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult CrearOrden()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Session["CrearOrden"] = "pend";
                 return RedirectToAction("Login", "Account");
            }

            string correo = User.Identity.Name;

            string fechaCreacion = DateTime.Today.ToShortDateString();
            string fechaProbEntrega = DateTime.Today.AddDays(3).ToShortDateString();
            var cliente = (from c in db.cliente
                           where c.email == correo
                           select c).ToList().FirstOrDefault();

            Session["dirCliente"] = cliente.calle_t + " " + cliente.colonia_t + " " + cliente.estado_t;
            Session["fechaOrden"] = fechaCreacion;
            Session["fPEntrega"] = fechaProbEntrega;

            if (cliente.num_tarj_cred_ppal.StartsWith("4")) 
            {
                Session["tTarj"] = "1";
            }
            if (cliente.num_tarj_cred_ppal.StartsWith("5"))
            {
                Session["tTarj"] = "2";
            }
            if (cliente.num_tarj_cred_ppal.StartsWith("3"))
            {
                Session["tTarj"] = "2";
            }
            Session["nTarj"] = cliente.num_tarj_cred_ppal;
            return View();
        }

        public ActionResult Pagar (string tipoPago)
        {
            string correo = User.Identity.Name;

            DateTime fechaCreacion = DateTime.Today;
            DateTime fechaProbEntrega = fechaCreacion.AddDays(3);
            var cliente = (from c in db.cliente
                           where c.email == correo
                           select c).ToList().FirstOrDefault();
            int idCliente = cliente.Id_cliente;

            if (tipoPago.Equals("T"))
            {
                if (!validaPago(cliente))
                {
                    return RedirectToAction("pagoNoAceptado");
                }
                else
                {
                    var dirEnt = (from d in db.dirEntrega
                                  where d.id_cliente == cliente.Id_cliente
                                  select d).ToList().FirstOrDefault();

                    int idDir = dirEnt.Id_dirEntrega;
                    return RedirectToAction("pagoAceptado", routeValues: new { idC = idCliente, idD = idDir });
                }
            }
            if (tipoPago.Equals("P"))
            {
                var dirEnt = (from d in db.dirEntrega
                              where d.id_cliente == cliente.Id_cliente
                              select d).ToList().FirstOrDefault();
            }
            return View();
        }

        private bool validaPago(cliente cliente)
        {
            bool retorna = true;
            int randomvalue;

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                byte[] val = new byte[6];
                crypto.GetBytes(val);
                randomvalue = BitConverter.ToInt32(val, 1);
            }
            NumConfPago = Math.Abs(randomvalue * 1000).ToString();
            Session["nConfirma"] = NumConfPago;
            return retorna;
        }

        public ActionResult pagoNoAceptado()
        {
            return View();
        }

        public ActionResult pagoAceptado(int idC, int idD)
        {
            orden orden_cliente = new orden();
            int id = 0;
            if (!(db.orden.Max(o => (int?)o.Id_orden) == null))
            {
                id = db.orden.Max(o => o.Id_orden);
            }
            else
            {
                id = 0;
            }

            id++;
            orden_cliente.Id_orden = id;
            orden_cliente.fecha_creacion = DateTime.Today;
            orden_cliente.num_confirmacion = Int32.Parse(Session["nConfirma"].ToString());
            var carro = Session["cart"] as List<item>;
            var total = carro.Sum(item => item.Producto.precio * item.Cantidad);
            orden_cliente.total = total;
            orden_cliente.id_cliente = idC;
            orden_cliente.id_dirEntrega = idD;
            db.orden.Add(orden_cliente);
            db.SaveChanges();

            orden_producto ordenProd;
            List<orden_producto> listaProdOr = new List<orden_producto>();
            foreach (item linea in carro)
            {
                ordenProd = new orden_producto();
                ordenProd.id_orden = orden_cliente.Id_orden;
                ordenProd.id_producto = linea.Producto.Id_producto;
                ordenProd.cantidad = linea.Cantidad;
                listaProdOr.Add(ordenProd);
                db.orden_producto.Add(ordenProd);
            }
            db.SaveChanges();

            Session["cart"] = null;
            Session["nConfirma"] = null;
            Session["itemTotal"] = 0;

            return View();
        }
    }
}