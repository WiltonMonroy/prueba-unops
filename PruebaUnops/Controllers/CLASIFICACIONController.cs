using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaUnops.Models;

namespace PruebaUnops.Controllers
{
    public class CLASIFICACIONController : Controller
    {
        private UnopsEntities db = new UnopsEntities();

        // GET: CLASIFICACION
        public ActionResult Index()
        {
            return View(db.CLASIFICACION.ToList());
        }

        // GET: CLASIFICACION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACION.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(cLASIFICACION);
        }

        // GET: CLASIFICACION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CLASIFICACION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLASIFICACION,NOMBRE")] CLASIFICACION cLASIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.CLASIFICACION.Add(cLASIFICACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLASIFICACION);
        }

        // GET: CLASIFICACION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACION.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(cLASIFICACION);
        }

        // POST: CLASIFICACION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLASIFICACION,NOMBRE")] CLASIFICACION cLASIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASIFICACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLASIFICACION);
        }

        // GET: CLASIFICACION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACION.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(cLASIFICACION);
        }

        // POST: CLASIFICACION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASIFICACION cLASIFICACION = db.CLASIFICACION.Find(id);
            db.CLASIFICACION.Remove(cLASIFICACION);
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
