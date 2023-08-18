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
    public class HorariosController : Controller
    {
        private Context db = new Context();

        // GET: Horarios
        public ActionResult Index()
        {
            var horarios = db.Horarios.Include(h => h.Curso).Include(h => h.Profesor);
            return View(horarios.ToList());
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            ViewBag.curso_id = new SelectList(db.Cursos, "curso_id", "nombre_curso");
            ViewBag.profesor_id = new SelectList(db.Profesores, "profesor_id", "nombre_profesor");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "horario_id,curso_id,profesor_id,dia_semana,hora_inicio,hora_final")] Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                db.Horarios.Add(horarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.curso_id = new SelectList(db.Cursos, "curso_id", "nombre_curso", horarios.curso_id);
            ViewBag.profesor_id = new SelectList(db.Profesores, "profesor_id", "nombre_profesor", horarios.profesor_id);
            return View(horarios);
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.curso_id = new SelectList(db.Cursos, "curso_id", "nombre_curso", horarios.curso_id);
            ViewBag.profesor_id = new SelectList(db.Profesores, "profesor_id", "nombre_profesor", horarios.profesor_id);
            return View(horarios);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "horario_id,curso_id,profesor_id,dia_semana,hora_inicio,hora_final")] Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.curso_id = new SelectList(db.Cursos, "curso_id", "nombre_curso", horarios.curso_id);
            ViewBag.profesor_id = new SelectList(db.Profesores, "profesor_id", "nombre_profesor", horarios.profesor_id);
            return View(horarios);
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horarios horarios = db.Horarios.Find(id);
            db.Horarios.Remove(horarios);
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
