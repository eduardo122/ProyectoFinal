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
    public class CARGOesController : Controller
    {
        private PROYECTO_FINALEntities1 db = new PROYECTO_FINALEntities1();

        // GET: CARGOes
        public ActionResult Index()
        {
            return View(db.CARGOes.ToList());
        }

        // GET: CARGOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGO cARGO = db.CARGOes.Find(id);
            if (cARGO == null)
            {
                return HttpNotFound();
            }
            return View(cARGO);
        }

        // GET: CARGOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CARGOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Cargo1")] CARGO cARGO)
        {
            if (ModelState.IsValid)
            {
                db.CARGOes.Add(cARGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cARGO);
        }

        // GET: CARGOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGO cARGO = db.CARGOes.Find(id);
            if (cARGO == null)
            {
                return HttpNotFound();
            }
            return View(cARGO);
        }

        // POST: CARGOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Cargo1")] CARGO cARGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cARGO);
        }

        // GET: CARGOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGO cARGO = db.CARGOes.Find(id);
            if (cARGO == null)
            {
                return HttpNotFound();
            }
            return View(cARGO);
        }

        // POST: CARGOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARGO cARGO = db.CARGOes.Find(id);
            db.CARGOes.Remove(cARGO);
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
