//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SALIDA
    {
        public int ID { get; set; }
        public Nullable<int> empleado { get; set; }
        public string tipo_salida { get; set; }
        public string motivo { get; set; }
        public Nullable<System.DateTime> fecha_salida { get; set; }
    
        public virtual EMPLEADO EMPLEADO1 { get; set; }
    }

    public enum Tipo {Renuncia, Despido, Desahucio }
}
