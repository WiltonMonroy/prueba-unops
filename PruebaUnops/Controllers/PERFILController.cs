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
    public class PERFILController : Controller
    {
        private UnopsEntities db = new UnopsEntities();

        // GET: PERFIL
        public ActionResult Index()
        {
            return View(db.PERFIL.ToList());
        }

        // GET: PERFIL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFIL pERFIL = db.PERFIL.Find(id);
            if (pERFIL == null)
            {
                return HttpNotFound();
            }
            return View(pERFIL);
        }

        // GET: PERFIL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PERFIL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PERFIL,NOMBRE")] PERFIL pERFIL)
        {
            if (ModelState.IsValid)
            {
                db.PERFIL.Add(pERFIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERFIL);
        }

        // GET: PERFIL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFIL pERFIL = db.PERFIL.Find(id);
            if (pERFIL == null)
            {
                return HttpNotFound();
            }
            return View(pERFIL);
        }

        // POST: PERFIL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PERFIL,NOMBRE")] PERFIL pERFIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERFIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pERFIL);
        }

        // GET: PERFIL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFIL pERFIL = db.PERFIL.Find(id);
            if (pERFIL == null)
            {
                return HttpNotFound();
            }
            return View(pERFIL);
        }

        // POST: PERFIL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERFIL pERFIL = db.PERFIL.Find(id);
            db.PERFIL.Remove(pERFIL);
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
