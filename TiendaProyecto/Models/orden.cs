//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaProyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class orden
    {
        public int Id_orden { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<decimal> num_confirmacion { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public Nullable<int> id_dirEntrega { get; set; }
        public Nullable<int> id_paqueteria { get; set; }
        public string num_guia { get; set; }
        public Nullable<System.DateTime> fecha_envio { get; set; }
        public Nullable<System.DateTime> fecha_entrega { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual paqueteria paqueteria { get; set; }
    }
}
