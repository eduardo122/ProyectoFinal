using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class EMPLEADOesController : Controller
    {
        private PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();
       

        // GET: EMPLEADOes
        public ActionResult Index()
        {
            var eMPLEADOS = db.EMPLEADOS.Include(e => e.CARGO1).Include(e => e.DEPARTAMENTO1);
            return View(eMPLEADOS.ToList());
        }

        // GET: EMPLEADOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Create
        public ActionResult Create()
        {
            ViewBag.cargo = new SelectList(db.CARGOes, "id", "Cargo1");
            ViewBag.departamento = new SelectList(db.DEPARTAMENTOS, "id", "nombre");
            return View();
        }

        // POST: EMPLEADOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo_empleado,nombre,apellido,telefono,departamento,cargo,fecha_ingreso,salario,estatus")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADOS.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cargo = new SelectList(db.CARGOes, "id", "Cargo1", eMPLEADO.cargo);
            ViewBag.departamento = new SelectList(db.DEPARTAMENTOS, "id", "nombre", eMPLEADO.departamento);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.cargo = new SelectList(db.CARGOes, "id", "Cargo1", eMPLEADO.cargo);
            ViewBag.departamento = new SelectList(db.DEPARTAMENTOS, "id", "nombre", eMPLEADO.departamento);
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo_empleado,nombre,apellido,telefono,departamento,cargo,fecha_ingreso,salario,estatus")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cargo = new SelectList(db.CARGOes, "id", "Cargo1", eMPLEADO.cargo);
            ViewBag.departamento = new SelectList(db.DEPARTAMENTOS, "id", "nombre", eMPLEADO.departamento);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            try
            { 
                db.EMPLEADOS.Remove(eMPLEADO);
                db.SaveChanges();
            }
            catch(Exception e){
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
