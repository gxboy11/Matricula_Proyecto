using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matricula_Proyecto.Models;

namespace Matricula_Proyecto.Controllers
{
    public class PrematriculasController : Controller
    {
        private Context db = new Context();

        // GET: Prematriculas
        public ActionResult Index()
        {
            var prematricula = db.Prematricula.Include(p => p.Estudiante).Include(p => p.horario);
            return View(prematricula.ToList());
        }

        // GET: Prematriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prematricula prematricula = db.Prematricula.Find(id);
            if (prematricula == null)
            {
                return HttpNotFound();
            }
            return View(prematricula);
        }

        // GET: Prematriculas/Create
        public ActionResult Create()
        {
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante");
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana");
            return View();
        }

        // POST: Prematriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prematricula_id,estudiante_id,horario_id")] Prematricula prematricula)
        {
            if (ModelState.IsValid)
            {
                db.Prematricula.Add(prematricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante", prematricula.estudiante_id);
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana", prematricula.horario_id);
            return View(prematricula);
        }

        // GET: Prematriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prematricula prematricula = db.Prematricula.Find(id);
            if (prematricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante", prematricula.estudiante_id);
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana", prematricula.horario_id);
            return View(prematricula);
        }

        // POST: Prematriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prematricula_id,estudiante_id,horario_id")] Prematricula prematricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prematricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante", prematricula.estudiante_id);
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana", prematricula.horario_id);
            return View(prematricula);
        }

        // GET: Prematriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prematricula prematricula = db.Prematricula.Find(id);
            if (prematricula == null)
            {
                return HttpNotFound();
            }
            return View(prematricula);
        }

        // POST: Prematriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prematricula prematricula = db.Prematricula.Find(id);
            db.Prematricula.Remove(prematricula);
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
