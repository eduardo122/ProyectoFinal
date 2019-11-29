
namespace ProyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEPARTAMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTAMENTO()
        {
            this.EMPLEADOS = new HashSet<EMPLEADO>();
        }
    
        public int id { get; set; }
        public Nullable<int> codigo_departamento { get; set; }
        public string nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADOS { get; set; }
    }
}