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
    using System.ComponentModel.DataAnnotations;

    public partial class VACACIONE
    {
        public int ID { get; set; }
        public int empleado { get; set; }
        [Required(ErrorMessage ="Se requiere la fecha de incio")]
        public Nullable<System.DateTime> desde { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha de regreso")]
        public Nullable<System.DateTime> hasta { get; set; }
        [Required(ErrorMessage = "Se requiere el año correspondiente")]
        public string correspondiente { get; set; }
        [Required(ErrorMessage = "Se requiere un comentario")]
        public string comentarios { get; set; }
    
        public virtual EMPLEADO EMPLEADO1 { get; set; }
    }
}
