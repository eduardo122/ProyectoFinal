using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Listas
    {
        public NOMINA ListaDeNominas { get; set; }
        public EMPLEADO ListaDeEmpleados { get; set; }
        public DEPARTAMENTO ListaDeDepartamentos { get; set; }
        public CARGO ListDeCargos { get; set; }
    }
}