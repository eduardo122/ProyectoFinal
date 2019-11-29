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
    public class DEPARTAMENTOesController : Controller
    {
        private PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();

        // GET: DEPARTAMENTOes
        public ActionResult Index()
        {
            return View(db.DEPARTAMENTOS.ToList());
        }

        // GET: DEPARTAMENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTOS.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEPARTAMENTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo_departamento,nombre")] DEPARTAMENTO dEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTAMENTOS.Add(dEPARTAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTOS.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // POST: DEPARTAMENTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo_departamento,nombre")] DEPARTAMENTO dEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTOS.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // POST: DEPARTAMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTOS.Find(id);
            db.DEPARTAMENTOS.Remove(dEPARTAMENTO);
            db.SaveChanges();
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
