namespace ProyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLEADO
    {
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
    }
}