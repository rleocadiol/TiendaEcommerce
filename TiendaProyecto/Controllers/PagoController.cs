using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaProyecto.Models;

namespace TiendaProyecto.Controllers
{
    public class PagoController : Controller
    {
        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }
      // public ActionResult CrearOrden()
       // {
         //   if (!User.Identity.IsAuthenticated)
           // {
             //   Session["CrearOrden"] = "pend";
               //  return RedirectToAction("Login", "Acount");
            //}
               //  var orden = new orden();
                 //var bd = new contextTienda();
        //}
    }
}