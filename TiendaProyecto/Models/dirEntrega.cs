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
    
    public partial class dirEntrega
    {
        public int Id_dirEntrega { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string estado { get; set; }
        public string tel { get; set; }
        public Nullable<int> id_cliente { get; set; }
    
        public virtual cliente cliente { get; set; }
    }
}
