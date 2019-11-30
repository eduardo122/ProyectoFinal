using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Mantenimientos() {

            return View();
        }

        public ActionResult Procesos()
        {

            return View();
        }

        public ActionResult Nomina() {

            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();

            List<EMPLEADO> empleadoslista = sd.EMPLEADOS.ToList();
            List<CARGO> cargolista = sd.CARGOes.ToList();
        
            ViewData["Empleados"] = from e in empleadoslista where e.estatus == "Activo"
                                    join c in cargolista on e.cargo equals c.id into table1 from c in table1.DefaultIfEmpty()
                                    select new ListaEmpleados { empleadoslista = e , cargoLista = c};

            return View(ViewData["Empleados"]);
        }

        public ActionResult ValidarNomina(int monto) {
            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();
            NOMINA NM = new NOMINA();

            int anio;
            if (String.IsNullOrEmpty(Request.Form["año"])) { anio = 2019; }

            else { anio = Int32.Parse((Request.Form["año"])); }
            NM.año = anio;
            NM.mes = Request.Form["mes"];
            NM.monto_total = monto;
            
            sd.NOMINAS.Add(NM);
            sd.SaveChanges(); 
            return View();
        }
    }
}