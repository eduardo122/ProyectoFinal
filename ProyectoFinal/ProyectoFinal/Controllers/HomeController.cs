﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

            if (!String.IsNullOrEmpty(NM.mes))
            {
                sd.NOMINAS.Add(NM);
                sd.SaveChanges();
                return RedirectToAction("Nomina");
            }
           
            return View();
        }

        public ActionResult Salida() {

            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();
            List<EMPLEADO> empleadoslista = sd.EMPLEADOS.ToList();
            List<CARGO> cargolista = sd.CARGOes.ToList();
            List<DEPARTAMENTO> departamentolista = sd.DEPARTAMENTOS.ToList();

            ViewData["Empleados"] = from e in empleadoslista
                                    where e.estatus == "Activo"
                                    join c in cargolista on e.cargo equals c.id into table1
                                    from c in table1.DefaultIfEmpty()
                                    join d in departamentolista on e.departamento equals d.id into table2
                                    from d in table2.DefaultIfEmpty()
                                    select new ListaEmpleados { empleadoslista = e, cargoLista = c, departamentolista=d };
            return View(ViewData["Empleados"]);
        }

        public ActionResult Validarsalida(int? id) {
            PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("ConfirmarSalida", id);
        }

        public ActionResult ConfirmarSalida(int? id) {
            PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();
            var Query = (from e in db.EMPLEADOS
                         where e.id == id
                         select e).FirstOrDefault();

            Query.estatus = "Inactivo";
            db.SaveChanges();
             
                SALIDA SLD = new SALIDA();
                SLD.empleado = id;
                SLD.tipo_salida = Request.Form["tipo_salida"];
                SLD.motivo = Request.Form["motivo"];
                SLD.fecha_salida = DateTime.Today;

            if (!String.IsNullOrEmpty(SLD.motivo)) {
                db.SALIDAS.Add(SLD);
                db.SaveChanges();
                return RedirectToAction("Salida");
            }


            return View();
        }



        public ActionResult Vacaciones() {
            PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();
            var getEmpleados = db.EMPLEADOS.ToList();
            
            SelectList lista = new SelectList(getEmpleados, "id", "Nombre", "Apellido", "","");
            ViewBag.empleados = lista;
   
            VACACIONE VC = new VACACIONE();

            int id;
            string desde = Request.Form["desde"];
            string hasta = Request.Form["hasta"];
            if (String.IsNullOrEmpty(Request.Form["empleado"])) { id = 0; }

            else { id = Int32.Parse((Request.Form["empleado"])); }


            VC.empleado = id;
            VC.desde = Convert.ToDateTime(desde);
            VC.hasta = Convert.ToDateTime(hasta);
            VC.correspondiente = Request.Form["correspondiente"];
            VC.comentarios = Request.Form["comentarios"];

            if (!String.IsNullOrEmpty(VC.comentarios)) {
                db.VACACIONES.Add(VC);
                db.SaveChanges();
                return RedirectToAction("Procesos");
            }
          

            return View();

        }


        public ActionResult Permisos() {
            PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();
            PERMISO PM = new PERMISO();
            var getEmpleados = db.EMPLEADOS.ToList();

            SelectList lista = new SelectList(getEmpleados, "id", "Nombre", "Apellido", "", "");
            ViewBag.empleados = lista;

            int id;
            string desde = Request.Form["desde"];
            string hasta = Request.Form["hasta"];
            if (String.IsNullOrEmpty(Request.Form["empleado"])) { id = 0; }

            else { id = Int32.Parse((Request.Form["empleado"])); }
            PM.empleado = id;
            PM.desde = Convert.ToDateTime(desde);
            PM.hasta = Convert.ToDateTime(hasta);
            PM.comentarios = Request.Form["comentarios"];

            if (!String.IsNullOrEmpty(PM.comentarios))
            {
                db.PERMISOS.Add(PM);
                db.SaveChanges();
                return RedirectToAction("Procesos");
            }

            return View();
        }

        public ActionResult Licencias() {
            PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();
            LICENCIA LC = new LICENCIA();
            var getEmpleados = db.EMPLEADOS.ToList();

            SelectList lista = new SelectList(getEmpleados, "id", "Nombre", "Apellido", "", "");
            ViewBag.empleados = lista;

            int id;
            string desde = Request.Form["desde"];
            string hasta = Request.Form["hasta"];
            if (String.IsNullOrEmpty(Request.Form["empleado"])) { id = 0; }

            else { id = Int32.Parse((Request.Form["empleado"])); }

            LC.empleado = id;
            LC.desde = Convert.ToDateTime(desde);
            LC.hasta = Convert.ToDateTime(hasta);
            LC.comentarios = Request.Form["comentarios"];
            LC.motivo = Request.Form["motivo"];
            if (!String.IsNullOrEmpty(LC.comentarios))
            {
                db.LICENCIAS.Add(LC);
                db.SaveChanges();
                return RedirectToAction("Procesos");
            }
            return View();
        }

        public ActionResult Informes() {
            return View();
        }

        public ActionResult InformeNomina() {
            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();

            List<NOMINA> listaNominas = sd.NOMINAS.ToList();
            

            ViewData["Nominas"] = from n in listaNominas
                                  select new Listas { ListaDeNominas = n};

            return View(ViewData["Nominas"]);

           
        }

        public ActionResult InformeEmpleadosActivos() {
            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();

            List<EMPLEADO> listaEmpleados = sd.EMPLEADOS.ToList();
            List<DEPARTAMENTO> listaDepartamento = sd.DEPARTAMENTOS.ToList();
            List<CARGO> listaCargo = sd.CARGOes.ToList();

            ViewData["EmpleadosActivos"] = from e in listaEmpleados
                                           where e.estatus == "Activo"
                                    join c in listaCargo on e.cargo equals c.id into table1 from c in table1.DefaultIfEmpty()
                                    join d in listaDepartamento on e.departamento equals d.id into table2 from d in table2.DefaultIfEmpty()
                                    select new Listas { ListaDeEmpleados = e, ListDeCargos = c, ListaDeDepartamentos = d };

            return View(ViewData["EmpleadosActivos"]);
        }

        public ActionResult InformeEmpleadosInactivos()
        {

            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();

            List<EMPLEADO> listaEmpleados = sd.EMPLEADOS.ToList();
            List<DEPARTAMENTO> listaDepartamento = sd.DEPARTAMENTOS.ToList();
            List<CARGO> listaCargo = sd.CARGOes.ToList();

            ViewData["EmpleadosInactivos"] = from e in listaEmpleados
                                           where e.estatus == "Inactivo"
                                           join c in listaCargo on e.cargo equals c.id into table1
                                           from c in table1.DefaultIfEmpty()
                                           join d in listaDepartamento on e.departamento equals d.id into table2
                                           from d in table2.DefaultIfEmpty()
                                           select new Listas { ListaDeEmpleados = e, ListDeCargos = c, ListaDeDepartamentos = d };

            return View(ViewData["EmpleadosInactivos"]);

        }

        public ActionResult InformeDepartamentos()
        {
            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();
            List<DEPARTAMENTO> listaDepartamento = sd.DEPARTAMENTOS.ToList();

            ViewData["Departamentos"] = from d in listaDepartamento select new Listas { ListaDeDepartamentos = d };
            return View(ViewData["Departamentos"]);

        }

        public ActionResult InformeCagos()
        {
            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();
            List<CARGO> listaCargo = sd.CARGOes.ToList();

            ViewData["Cargos"] = from c in listaCargo select new Listas { ListDeCargos = c };
            return View(ViewData["Cargos"]);

        }

        public ActionResult InformeEmpleadosMes() {

        
            return View();
        }

        public ActionResult busquedaEmpleadoMes(string mes) {
           
            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();
            List<EMPLEADO> empleadoslista = sd.EMPLEADOS.ToList();
            List<CARGO> cargolista = sd.CARGOes.ToList();

            int miMes = 0;
            switch (mes)
            {
                case "Enero":
                    miMes = 1;
                    break;
                case "Febrero":
                    miMes = 2;
                    break;
                case "Marzo":
                    miMes = 3;
                    break;
                case "Abril":
                    miMes = 4;
                    break;
                case "Mayo":
                    miMes = 5;
                    break;
                case "Junio":
                    miMes = 6;
                    break;
                case "Julio":
                    miMes = 7;
                    break;
                case "Agosto":
                    miMes = 8;
                    break;
                case "Septiembre":
                    miMes = 9;
                    break;
                case "Octubre":
                    miMes = 10;
                    break;
                case "Noviembre":
                    miMes = 11;
                    break;
                case "Diciembre":
                    miMes = 12;
                    break;

            }

            ViewData["EmpleadosEntradaMes"] = from e in empleadoslista
                                    where e.fecha_ingreso.Month ==miMes
                                    join c in cargolista on e.cargo equals c.id into table1
                                    from c in table1.DefaultIfEmpty()
                                    select new Listas { ListaDeEmpleados = e, ListDeCargos = c };

            return View(ViewData["EmpleadosEntradaMes"]);
           
        }

        public ActionResult InformeSalidaMes() {

            return View();
        }

        public ActionResult busquedaSalidaMes(string mes)
        {

            PROYECTO_FINALEntities1 sd = new PROYECTO_FINALEntities1();
            List<SALIDA> salidaslista = sd.SALIDAS.ToList();
            List<EMPLEADO> empleadoslista = sd.EMPLEADOS.ToList();


            int miMes = 0;  
            switch (mes)
            {
                case "Enero":
                    miMes = 1;
                    break;
                case "Febrero":
                    miMes = 2;
                    break;
                case "Marzo":
                    miMes = 3;
                    break;
                case "Abril":
                    miMes = 4;
                    break;
                case "Mayo":
                    miMes = 5;
                    break;
                case "Junio":
                    miMes = 6;
                    break;
                case "Julio":
                    miMes = 7;
                    break;
                case "Agosto":
                    miMes = 8;
                    break;
                case "Septiembre":
                    miMes = 9;
                    break;
                case "Octubre":
                    miMes = 10;
                    break;
                case "Noviembre":
                    miMes = 11;
                    break;
                case "Diciembre":
                    miMes = 12;
                    break;

            }

            ViewData["SalidasMes"] = from s in salidaslista
                                              where s.fecha_salida.Month == miMes
                                              join e in empleadoslista on s.empleado equals e.id into table1
                                              from e in table1.DefaultIfEmpty()
                                              select new Listas { listaDeSalidas = s, ListaDeEmpleados = e};
          
            return View(ViewData["SalidasMes"]);

        }


        public ActionResult InformePermisos() {
            PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();
          
            var getEmpleados = db.EMPLEADOS.ToList();

            SelectList lista = new SelectList(getEmpleados, "id", "Nombre", "Apellido", "", "");
            ViewBag.empleados = lista;

            return View();
        }

        public ActionResult BuscarPermiso(int empleado) {
            PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();
            List<PERMISO> permisoLista = db.PERMISOS.ToList();
            List<EMPLEADO> empleadoLista = db.EMPLEADOS.ToList();
            int id = Int32.Parse((Request.Form["empleado"]));

            ViewData["permisos"] = from p in permisoLista where p.empleado == empleado
                               join e in empleadoLista on p.empleado equals e.id into table1
                               from e in table1.DefaultIfEmpty()
                               select new Listas { listaDePermisos = p, ListaDeEmpleados= e };

            

            return View(ViewData["permisos"]);
        }

    }
}

