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
    public class PRIORIDADController : Controller
    {
        private UnopsEntities db = new UnopsEntities();

        // GET: PRIORIDAD
        public ActionResult Index()
        {
            var pRIORIDAD = db.PRIORIDAD.Include(p => p.INCIDENCIA);
            return View(pRIORIDAD.ToList());
        }

        // GET: PRIORIDAD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIORIDAD pRIORIDAD = db.PRIORIDAD.Find(id);
            if (pRIORIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pRIORIDAD);
        }

        // GET: PRIORIDAD/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRIORIDAD = new SelectList(db.INCIDENCIA, "ID_PRIORIDAD", "ASUNTO");
            return View();
        }

        // POST: PRIORIDAD/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRIORIDAD,NOMBRE")] PRIORIDAD pRIORIDAD)
        {
            if (ModelState.IsValid)
            {
                db.PRIORIDAD.Add(pRIORIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRIORIDAD = new SelectList(db.INCIDENCIA, "ID_PRIORIDAD", "ASUNTO", pRIORIDAD.ID_PRIORIDAD);
            return View(pRIORIDAD);
        }

        // GET: PRIORIDAD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIORIDAD pRIORIDAD = db.PRIORIDAD.Find(id);
            if (pRIORIDAD == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRIORIDAD = new SelectList(db.INCIDENCIA, "ID_PRIORIDAD", "ASUNTO", pRIORIDAD.ID_PRIORIDAD);
            return View(pRIORIDAD);
        }

        // POST: PRIORIDAD/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRIORIDAD,NOMBRE")] PRIORIDAD pRIORIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRIORIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRIORIDAD = new SelectList(db.INCIDENCIA, "ID_PRIORIDAD", "ASUNTO", pRIORIDAD.ID_PRIORIDAD);
            return View(pRIORIDAD);
        }

        // GET: PRIORIDAD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIORIDAD pRIORIDAD = db.PRIORIDAD.Find(id);
            if (pRIORIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pRIORIDAD);
        }

        // POST: PRIORIDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRIORIDAD pRIORIDAD = db.PRIORIDAD.Find(id);
            db.PRIORIDAD.Remove(pRIORIDAD);
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
