using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaProyecto.Models
{
    public class prodCarro
    {
        private contextTienda db = new contextTienda();
        private List<producto> productos;
        public prodCarro()
        {
            productos = db.producto.ToList();
        }

        public List<producto> findAll()
        {
            return this.productos;
        }

        public producto find (int id)
        {
            producto pp = this.productos.Single(p => p.Id_producto.Equals(id));
            return pp;
        }
    }
}