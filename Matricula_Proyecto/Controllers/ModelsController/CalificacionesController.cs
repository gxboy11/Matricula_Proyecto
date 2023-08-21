using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matricula_Proyecto.Models;

namespace Matricula_Proyecto.Controllers.ModelsController
{
    public class CalificacionesController : Controller
    {
        private Context db = new Context();

        // GET: Calificaciones
        public ActionResult Index()
        {
            var calificaciones = db.Calificaciones.Include(c => c.estudiante).Include(c => c.horario);
            return View(calificaciones.ToList());
        }

        // GET: Calificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificaciones calificaciones = db.Calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            return View(calificaciones);
        }

        // GET: Calificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificaciones calificaciones = db.Calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante", calificaciones.estudiante_id);
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana", calificaciones.horario_id);
            return View(calificaciones);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "calificacion_id,estudiante_id,horario_id,nota_curso")] Calificaciones calificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante", calificaciones.estudiante_id);
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana", calificaciones.horario_id);
            return View(calificaciones);
        }

        // GET: Calificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificaciones calificaciones = db.Calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            return View(calificaciones);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificaciones calificaciones = db.Calificaciones.Find(id);
            db.Calificaciones.Remove(calificaciones);
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
