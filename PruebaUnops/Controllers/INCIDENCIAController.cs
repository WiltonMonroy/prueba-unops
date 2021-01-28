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
    public class INCIDENCIAController : Controller
    {
        private UnopsEntities db = new UnopsEntities();

        // GET: INCIDENCIA
        public ActionResult Index()
        {
            var iNCIDENCIA = db.INCIDENCIA.Include(i => i.CLASIFICACION).Include(i => i.ESTADO).Include(i => i.PRIORIDAD).Include(i => i.USUARIO);
            return View(iNCIDENCIA.ToList());
        }

        // GET: INCIDENCIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENCIA iNCIDENCIA = db.INCIDENCIA.Find(id);
            if (iNCIDENCIA == null)
            {
                return HttpNotFound();
            }
            return View(iNCIDENCIA);
        }

        // GET: INCIDENCIA/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLASIFICACION = new SelectList(db.CLASIFICACION, "ID_CLASIFICACION", "NOMBRE");
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE");
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE");
            return View();
        }

        // POST: INCIDENCIA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRIORIDAD,ID_INCIDENCIA,ID_USUARIO,ID_CLASIFICACION,ID_ESTADO,ASUNTO,HORAS")] INCIDENCIA iNCIDENCIA)
        {
            if (ModelState.IsValid)
            {
                db.INCIDENCIA.Add(iNCIDENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLASIFICACION = new SelectList(db.CLASIFICACION, "ID_CLASIFICACION", "NOMBRE", iNCIDENCIA.ID_CLASIFICACION);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE", iNCIDENCIA.ID_ESTADO);
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE", iNCIDENCIA.ID_PRIORIDAD);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", iNCIDENCIA.ID_USUARIO);
            return View(iNCIDENCIA);
        }

        // GET: INCIDENCIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENCIA iNCIDENCIA = db.INCIDENCIA.Find(id);
            if (iNCIDENCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLASIFICACION = new SelectList(db.CLASIFICACION, "ID_CLASIFICACION", "NOMBRE", iNCIDENCIA.ID_CLASIFICACION);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE", iNCIDENCIA.ID_ESTADO);
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE", iNCIDENCIA.ID_PRIORIDAD);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", iNCIDENCIA.ID_USUARIO);
            return View(iNCIDENCIA);
        }

        // POST: INCIDENCIA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRIORIDAD,ID_INCIDENCIA,ID_USUARIO,ID_CLASIFICACION,ID_ESTADO,ASUNTO,HORAS")] INCIDENCIA iNCIDENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNCIDENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLASIFICACION = new SelectList(db.CLASIFICACION, "ID_CLASIFICACION", "NOMBRE", iNCIDENCIA.ID_CLASIFICACION);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE", iNCIDENCIA.ID_ESTADO);
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE", iNCIDENCIA.ID_PRIORIDAD);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", iNCIDENCIA.ID_USUARIO);
            return View(iNCIDENCIA);
        }

        // GET: INCIDENCIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENCIA iNCIDENCIA = db.INCIDENCIA.Find(id);
            if (iNCIDENCIA == null)
            {
                return HttpNotFound();
            }
            return View(iNCIDENCIA);
        }

        // POST: INCIDENCIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INCIDENCIA iNCIDENCIA = db.INCIDENCIA.Find(id);
            db.INCIDENCIA.Remove(iNCIDENCIA);
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
