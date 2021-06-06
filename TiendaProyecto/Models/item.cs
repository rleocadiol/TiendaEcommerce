using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaProyecto.Models
{
    public class item
    {
        public producto Producto
        {
            get;
            set;
        }
        public int Cantidad
        {
            get;
            set;
        }
    }
}