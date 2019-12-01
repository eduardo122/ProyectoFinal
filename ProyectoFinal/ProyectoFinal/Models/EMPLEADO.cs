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
    
    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            this.SALIDAS = new HashSet<SALIDA>();
            this.VACACIONES = new HashSet<VACACIONE>();
            this.PERMISOS = new HashSet<PERMISO>();
            this.LICENCIAS = new HashSet<LICENCIA>();
        }
    
        public int id { get; set; }
        public string codigo_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public Nullable<int> departamento { get; set; }
        public Nullable<int> cargo { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
        public Nullable<int> salario { get; set; }
        public string estatus { get; set; }
    
        public virtual CARGO CARGO1 { get; set; }
        public virtual DEPARTAMENTO DEPARTAMENTO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALIDA> SALIDAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VACACIONE> VACACIONES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERMISO> PERMISOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICENCIA> LICENCIAS { get; set; }
    }
        public enum Estatus { Activo, Inactivo }
}
