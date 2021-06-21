﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaProyecto.Models;

namespace TiendaProyecto.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private dbutContext db = new dbutContext();
        // GET: Usuario
        public ActionResult Index(string email)
        {
            if (User.Identity.IsAuthenticated)
            {
                string correo = email;
                string rol = "";

                using (db)
                {
                    var query = from st in db.empleado
                                where st.email == correo
                                select st;
                    var lista = query.ToList();
                    if (lista.Count > 0)
                    {
                        var empleado = query.FirstOrDefault<empleado>();
                        string[] nombres = empleado.nombre.ToString().Split(' ');
                        Session["name"] = nombres;
                        Session["usr"] = empleado.nombre;
                        rol = empleado.rol.ToString().TrimEnd();
                    }
                    else
                    {
                        var query1 = from st in db.cliente
                                     where st.email == correo
                                     select st;
                        var lista1 = query.ToList();
                        if (lista1.Count > 0)
                        {
                            var cliente = query1.FirstOrDefault<cliente>();
                            string[] nombres = cliente.nombre.ToString().Split(' ');
                            Session["name"] = nombres;
                            Session["usr"] = cliente.nombre;
                            rol = "cliente";
                        }
                    }
                }
                if (rol == "comprador")
                {
                    return RedirectToAction("Index", "Compras");
                }
                if (rol == "enviador")
                {
                    return RedirectToAction("Index", "Envios");
                }
                if (rol == "chateador")
                {
                    return RedirectToAction("Index", "Chat");
                }
                if (rol == "cliente")
                {
                    return RedirectToAction("Index", "Home");
                }
                if (rol == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}